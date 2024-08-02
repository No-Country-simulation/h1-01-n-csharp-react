using AutoMapper;
using Core.Behaviors;
using Core.Services.Interfaces;
using DTOs;
using DTOs.Medic;
using DTOs.Patient;
using DTOs.Register;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<MedicService> _logger;
        private readonly IValidationBehavior<RegisterMedicRequest> _validationBehavior;
        private readonly IMedicRepository _medicRepository;
        private readonly IMapper _mapper;

        public MedicService(
            IAuthenticationService authenticationService,
            IHttpContextAccessor contextAccessor,
            ILogger<MedicService> logger,
            IValidationBehavior<RegisterMedicRequest> validationBehavior,
            IMedicRepository medicRepository,
            IMapper mapper)
        {
            _authenticationService = authenticationService;
            _contextAccessor = contextAccessor;
            _logger = logger;
            _validationBehavior = validationBehavior;
            _medicRepository = medicRepository;
            _mapper = mapper;
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

        public async Task<ServiceResponse<PatientMedicsGetDto>> GetMedicUserData(int medicId)
        {
            var serviceResponse = new ServiceResponse<PatientMedicsGetDto>();

            try
            {
                var medic = await _medicRepository.GetByIdAsync(medicId, m => m.Specialty, m => m.ApplicationUser);

                serviceResponse.Data = _mapper.Map<PatientMedicsGetDto>(medic);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener información del Médico - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
