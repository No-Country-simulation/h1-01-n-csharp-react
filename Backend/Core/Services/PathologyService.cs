using Core.Services.Interfaces;
using DTOs;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Pathology;

namespace Core.Services
{
    public class PathologyService : IPathologyService
    {
        private readonly ILogger<PathologyService> _logger;
        private readonly IPathologyRepository _pathologyRepository;

        public PathologyService(
            ILogger<PathologyService> logger,
            IPathologyRepository pathologyRepository)
        {
            _logger = logger;
            _pathologyRepository = pathologyRepository;
        }

        public async Task<ServiceResponse<List<PathologyGetDto>>> GetAllPathologies()
        {
            var serviceResponse = new ServiceResponse<List<PathologyGetDto>>();

            try
            {
                serviceResponse.Data = await _pathologyRepository.GetAllPathologies();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener Patologías - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PathologyCategoriesGetDto>>> GetAllPathologyCategories()
        {
            var serviceResponse = new ServiceResponse<List<PathologyCategoriesGetDto>>();

            try
            {
                serviceResponse.Data = await _pathologyRepository.GetAllPathologyCategories();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener las Categorías - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
