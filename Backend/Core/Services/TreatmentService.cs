using Core.Services.Interfaces;
using DTOs.Treatment;
using DTOs;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Medical;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Domain.Entities.Users;
using Core.Behaviors;

namespace Core.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ILogger<TreatmentService> _logger;
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMedicRepository _medicRepository;
        private readonly IMedicPatientRepository _medicPatientRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IValidationBehavior<TreatmentAddDto> _validationBehavior;

        public TreatmentService(
            ILogger<TreatmentService> logger,
            ITreatmentRepository treatmentRepository,
            IPatientRepository patientRepository,
            IMedicRepository medicRepository,
            IMedicPatientRepository medicPatientRepository,
            UserManager<ApplicationUser> userManager,
            IValidationBehavior<TreatmentAddDto> validationBehavior) 
        {
            _logger = logger;
            _treatmentRepository = treatmentRepository;
            _patientRepository = patientRepository;
            _medicRepository = medicRepository;
            _medicPatientRepository = medicPatientRepository;
            _userManager = userManager;
            _validationBehavior = validationBehavior;
        }

        public async Task<ServiceResponse<bool>> AddTreatmentToPatient(int medicId, string patientEmail, TreatmentAddDto request)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                var patientUser = await _userManager.FindByEmailAsync(patientEmail);
                var patientId = patientUser.PatientId;

                if (patientUser == null || patientUser.PatientId == null || patientUser.IsDeleted)
                {
                    throw new KeyNotFoundException("Usuario no encontrado, no es un paciente o fue eliminado.");
                }

                var patient = await _patientRepository.GetByIdAsync(patientId.Value);
                if (patient.MedRecordId == null) throw new KeyNotFoundException("El Paciente no tiene un MedRecord");

                var existingRelationship = await _medicPatientRepository.FindRelationship(medicId, patientId.Value);
                if (existingRelationship == null) throw new Exception("No existe una relación con este usuario.");

                await _validationBehavior.ValidateFields(request);

                var medic = await _medicRepository.GetByIdAsync(medicId, m => m.Specialty);

                Treatment treatment = new Treatment()
                {
                    Name = request.Name,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    MedRecordId = patient.MedRecordId.Value,
                    PathologyId = request.PathologyId,
                    CreatorName = $"{medic.FirstName} {medic.LastName}",
                    CreatorSpecialty = medic.Specialty.Type,
                    MedDosages = request.MedDosages.Select(md => new MedDosage
                    {
                        CurrentDosage = md.CurrentDosage,
                        Instructions = md.Instructions,
                        MedicineId = md.MedicineId
                    }).ToList()

                };

                await _treatmentRepository.Insert(treatment);
                await _treatmentRepository.SaveChangesAsync();


                serviceResponse.Data = true;
                serviceResponse.Message = "Tratamiento agregado con éxito al paciente.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al agregar nuevo Tratamiento - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
