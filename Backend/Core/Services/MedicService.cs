﻿using Core.Behaviors;
using Core.Services.Interfaces;
using DTOs;
using DTOs.Register;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class MedicService : IMedicService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<MedicService> _logger;
        private readonly IValidationBehavior<RegisterMedicRequest> _validationBehavior;

        public MedicService(
            IAuthenticationService authenticationService,
            ILogger<MedicService> logger,
            IValidationBehavior<RegisterMedicRequest> validationBehavior)
        {
            _authenticationService = authenticationService;
            _logger = logger;
            _validationBehavior = validationBehavior;
        }

        public async Task<ServiceResponse<RegisterResponse>> RegisterMedicUser(RegisterMedicRequest request)
        {
            var serviceResponse = new ServiceResponse<RegisterResponse>();

            try
            {
                await _validationBehavior.ValidateFields(request);

                RegisterResponse registerResponse =
                    await _authenticationService.RegisterMedicAsync(request);

                serviceResponse.Data = registerResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al agregar nuevo Médico - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
