using Core.Behaviors;
using Core.Services.Interfaces;
using Domain.Entities.Medical;
using Domain.Entities.Users;
using DTOs;
using DTOs.Appointment;
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
    public class AppointmentService : IAppointmentService
    {
        private readonly ILogger<AppointmentService> _logger;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMedRecordRepository _medRecordRepository;
        private readonly IMedicPatientRepository _medicPatientRepository;
        private readonly IMedicRepository _medicRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IValidationBehavior<AppointmentAddDto> _validationBehavior;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppointmentService(
            ILogger<AppointmentService> logger,
            IAppointmentRepository appointmentRepository,
            IMedRecordRepository medRecordRepository,
            IMedicPatientRepository medicPatientRepository,
            IMedicRepository medicRepository,
            IPatientRepository patientRepository,
            IValidationBehavior<AppointmentAddDto> validationBehavior,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _appointmentRepository = appointmentRepository;
            _medRecordRepository = medRecordRepository;
            _medicPatientRepository = medicPatientRepository;
            _medicRepository = medicRepository;
            _patientRepository = patientRepository;
            _validationBehavior = validationBehavior;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<bool>> AddAppointmentToPatient(int medicId, string patientEmail, AppointmentAddDto request)
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


                Appointment appointment = new Appointment()
                {
                    Date = request.Date,
                    Hour = request.Hour,
                    AppointmentType = request.AppointmentType,
                    IsActive = request.IsActive,
                    MedicId = medicId,
                    MedRecordId = patient.MedRecordId.Value,
                };

                await _appointmentRepository.Insert(appointment);
                await _appointmentRepository.SaveChangesAsync();


                serviceResponse.Data = true;
                serviceResponse.Message = "Turno agregado con éxito al paciente.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al agregar nuevo Turno - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
