using Azure.Core;
using Core.Behaviors;
using Core.Services.Interfaces;
using Domain.Entities.Medical;
using Domain.Entities.Users;
using DTOs;
using DTOs.MedRecord;
using DTOs.Register;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class MedRecordService : IMedRecordService
    {
        private readonly ILogger<MedRecordService> _logger;
        private readonly IMedRecordRepository _medRecordRepository;
        private readonly IMedicPatientRepository _medicPatientRepository;
        private readonly IMedicRepository _medicRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IValidationBehavior<MedRecordAddDto> _validationBehavior;

        public MedRecordService(
            ILogger<MedRecordService> logger,
            IMedRecordRepository medRecordRepository,
            IMedicPatientRepository medicPatientRepository,
            IMedicRepository medicRepository,
            IPatientRepository patientRepository,
            IUserRepository userRepository,
            IValidationBehavior<MedRecordAddDto> validationBehavior)
        {
            _logger = logger;
            _medRecordRepository = medRecordRepository;
            _medicPatientRepository = medicPatientRepository;
            _medicRepository = medicRepository;
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _validationBehavior = validationBehavior;
        }

        public async Task<ServiceResponse<bool>> AddMedRecordToPatient(int medicId, int patientId, MedRecordAddDto request)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var patientUser = await _userRepository.GetPatientUser(patientId);
                if (patientUser == null || patientUser.PatientId == null || patientUser.IsDeleted)
                {
                    throw new KeyNotFoundException("Usuario no encontrado, no es un paciente o fue eliminado.");
                }

                var existingRelationship = await _medicPatientRepository.FindRelationship(medicId, patientId);
                if (existingRelationship == null) throw new Exception("No existe una relación con este usuario.");


                await _validationBehavior.ValidateFields(request);

                var medicUser = await _medicRepository.GetByIdAsync(medicId, m => m.Specialty);
                var patient = await _patientRepository.GetByIdAsync(patientId);

                if(patient.MedRecordId != null)
                {
                    throw new Exception("Este paciente ya tiene un MedRecord.");
                }

                MedRecord record = new MedRecord()
                {
                    PatientId = patientId,
                    Weight = request.Weight,
                    Height = request.Height,
                    IsAlcoholic = request.IsAlcoholic,
                    IsSmoker = request.IsSmoker,
                    UsesDrugs = request.UsesDrugs,
                    Note = $"{request.Note} (Creado por {medicUser.FirstName} {medicUser.LastName} - {medicUser.Specialty.Type})",
                };

                await _medRecordRepository.Insert(record);
                await _medRecordRepository.SaveChangesAsync();

                //Update Patient to add the new MedRecordId
                patient.MedRecordId = record.Id;
                _patientRepository.Update(patient);
                await _patientRepository.SaveChangesAsync();
                


                serviceResponse.Data = true;
                serviceResponse.Message = "MedRecord agregado con éxito al paciente.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al agregar nuevo MedRecord - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<MedRecordGetDto>> GetPatientMedRecord(int medicId, int patientId)
        {
            var serviceResponse = new ServiceResponse<MedRecordGetDto>();

            try
            {
                var patientUser = await _userRepository.GetPatientUser(patientId);
                if (patientUser == null || patientUser.PatientId == null || patientUser.IsDeleted)
                {
                    throw new KeyNotFoundException("Usuario no encontrado, no es un paciente o fue eliminado.");
                }

                var existingRelationship = await _medicPatientRepository.FindRelationship(medicId, patientId);
                if (existingRelationship == null) throw new Exception("No existe una relación con este usuario.");

                var patient = await _patientRepository.GetByIdAsync(patientId);

                if (patient.MedRecordId == null)
                {
                    throw new Exception("Este paciente no tiene un MedRecord.");
                }

                var record = await _medRecordRepository.GetMedRecordWithAllHistories(patient.MedRecordId.Value);


                serviceResponse.Data = record;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener MedRecord - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
