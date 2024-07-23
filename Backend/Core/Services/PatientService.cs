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

namespace Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<PatientService> _logger;
        private readonly IValidationBehavior<RegisterPatientRequest> _validationBehavior;

        public PatientService(
            IAuthenticationService authenticationService,
            ILogger<PatientService> logger,
            IValidationBehavior<RegisterPatientRequest> validationBehavior)
        {
            _authenticationService = authenticationService;
            _logger = logger;
            _validationBehavior = validationBehavior;
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
    }
}
