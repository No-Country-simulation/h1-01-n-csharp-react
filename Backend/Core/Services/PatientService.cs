using Core.Services.Interfaces;
using DTOs.Register;
using DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<PatientService> _logger;

        public PatientService(
            IAuthenticationService authenticationService,
            ILogger<PatientService> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        public async Task<ServiceResponse<RegisterResponse>> RegisterPatientUser(RegisterPatientRequest request)
        {
            var serviceResponse = new ServiceResponse<RegisterResponse>();

            try
            {
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
