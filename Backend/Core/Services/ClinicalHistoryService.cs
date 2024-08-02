using Core.Behaviors;
using Core.Services.Interfaces;
using Domain.Entities.Medical;
using Domain.Entities.Users;
using DTOs;
using DTOs.ClinicalHistory;
using DTOs.MedRecord;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ClinicalHistoryService : IClinicalHistoryService
    {
        private readonly ILogger<ClinicalHistoryService> _logger;
        private readonly IValidationBehavior<ClinicalHistoryAddDto> _validationBehavior;
        private readonly IClinicalHistoryRepository _clinicalHistoryRepository;
        private readonly IMedRecordRepository _medRecordRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMedicPatientRepository _medicPatientRepository;
        private readonly IMedicRepository _medicRepository;

        public ClinicalHistoryService(
            ILogger<ClinicalHistoryService> logger,
            IValidationBehavior<ClinicalHistoryAddDto> validationBehavior,
            IClinicalHistoryRepository clinicalHistoryRepository,
            IMedRecordRepository medRecordRepository,
            IUserRepository userRepository,
            IMedicPatientRepository medicPatientRepository,
            IMedicRepository medicRepository)
        {
            _logger = logger;
            _validationBehavior = validationBehavior;
            _clinicalHistoryRepository = clinicalHistoryRepository;
            _medRecordRepository = medRecordRepository;
            _userRepository = userRepository;
            _medicPatientRepository = medicPatientRepository;
            _medicRepository = medicRepository;
        }

        public async Task<ServiceResponse<bool>> AddClinicalHistory(int medicId, int medRecordId, ClinicalHistoryAddDto request)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var medRecord = await _medRecordRepository.GetByIdAsync(medRecordId, mr => mr.Patient);

                if(medRecord == null) throw new KeyNotFoundException("El MedRecord no existe");

                var patientId = medRecord.Patient.Id;

                var patientUser = await _userRepository.GetPatientUser(patientId);
                if (patientUser == null || patientUser.PatientId == null || patientUser.IsDeleted)
                {
                    throw new KeyNotFoundException("Usuario no encontrado, no es un paciente o fue eliminado.");
                }

                var existingRelationship = await _medicPatientRepository.FindRelationship(medicId, patientId);
                if (existingRelationship == null) throw new Exception("No existe una relación con este usuario.");
                await _validationBehavior.ValidateFields(request);

                var medicUser = await _medicRepository.GetByIdAsync(medicId, m => m.Specialty);

                ClinicalHistory history = new ClinicalHistory()
                {
                    MedicName = request.MedicName,
                    Details = request.Details,
                    DiagnosisDate = request.DiagnosisDate,
                    IsActive = request.IsActive,
                    CreatorName = $"{medicUser.FirstName} {medicUser.LastName}",
                    CreatorSpecialty = medicUser.Specialty.Type,
                    MedRecordId = medRecordId,
                    PathologyId = request.PathologyId,
                };

                await _clinicalHistoryRepository.Insert(history);
                await _clinicalHistoryRepository.SaveChangesAsync();


                serviceResponse.Data = true;
                serviceResponse.Message = "ClinicalHistory agregada con éxito al paciente.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al agregar nueva ClinicalHistory - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ClinicalHistoryGetDto>>> GetClinicalHistoriesFromRecord(int medicId, int medRecordId)
        {
            var serviceResponse = new ServiceResponse<List<ClinicalHistoryGetDto>>();

            try
            {
                var medRecord = await _medRecordRepository.GetByIdAsync(medRecordId, mr => mr.Patient);

                if (medRecord == null) throw new KeyNotFoundException("El MedRecord no existe");

                var patientId = medRecord.Patient.Id;

                var patientUser = await _userRepository.GetPatientUser(patientId);
                if (patientUser == null || patientUser.PatientId == null || patientUser.IsDeleted)
                {
                    throw new KeyNotFoundException("Usuario no encontrado, no es un paciente o fue eliminado.");
                }

                var existingRelationship = await _medicPatientRepository.FindRelationship(medicId, patientId);
                if (existingRelationship == null) throw new Exception("No existe una relación con este usuario.");


                var record = await _clinicalHistoryRepository.GetAllClinicalHistories(medRecordId);


                serviceResponse.Data = record;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener ClinicalHistories - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
