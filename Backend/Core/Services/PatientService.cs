using Core.Services.Interfaces;
using DTOs.Register;
using DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Behaviors;
using DTOs.Patient;
using Azure.Core;
using Infrastructure.Repositories.Interfaces;

namespace Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IPatientRepository _patientRepository;
        private readonly ILogger<PatientService> _logger;
        private readonly IValidationBehavior<RegisterPatientRequest> _validationBehavior;

        public PatientService(
            IAuthenticationService authenticationService,
            ILogger<PatientService> logger,
            IValidationBehavior<RegisterPatientRequest> validationBehavior,
            IPatientRepository patientRepository)
        {
            _authenticationService = authenticationService;
            _logger = logger;
            _validationBehavior = validationBehavior;
            _patientRepository = patientRepository;
        }

        public async Task<ServiceResponse<RegisterResponse>> RegisterPatientUser(RegisterPatientRequest request)
        {
            var serviceResponse = new ServiceResponse<RegisterResponse>();

            try
            {
                await _validationBehavior.ValidateFields(request);

                RegisterResponse registerResponse =
                    await _authenticationService.RegisterPatientAsync(request);

                serviceResponse.Data = registerResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al agregar nuevo Paciente - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PatientEmailGetDto>>> GetPatientsEmail(string email)
        {
            var serviceResponse = new ServiceResponse<List<PatientEmailGetDto>>();

            try
            {
                if (string.IsNullOrWhiteSpace(email) || email.Length < 3)
                    throw new ArgumentException("El email debe tener al menos 3 caracteres", nameof(email));

                serviceResponse.Data = await _patientRepository.GetPatientsEmail(email);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener Pacientes - {ex.Message}");
            }

            return serviceResponse;
        }

    }
}
