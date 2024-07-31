using DTOs.Surgical;
using DTOs;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Pathology;
using Infrastructure.Repositories;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class SurgicalHistoryService : ISurgicalHistoryService
    {
        private readonly ILogger<SurgicalHistoryService> _logger;
        private readonly ISurgicalHistoryRepository _surgicalHistoryRepository;

        public SurgicalHistoryService(
            ILogger<SurgicalHistoryService> logger,
            ISurgicalHistoryRepository surgicalHistoryRepository)
        {
            _logger = logger;
            _surgicalHistoryRepository = surgicalHistoryRepository;
        }

        public async Task<ServiceResponse<List<SurgeryTypesGetDto>>> GetAllSurgeryTypes()
        {
            var serviceResponse = new ServiceResponse<List<SurgeryTypesGetDto>>();

            try
            {
                serviceResponse.Data = await _surgicalHistoryRepository.GetAllSurgeryTypes();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener tipos de Cirugía - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
