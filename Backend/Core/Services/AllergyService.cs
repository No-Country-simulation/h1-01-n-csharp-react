using Core.Services.Interfaces;
using DTOs;
using DTOs.Allergy;
using DTOs.Pathology;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AllergyService : IAllergyService
    {
        private readonly ILogger<AllergyService> _logger;
        private readonly IAllergyRepository _allergyRepository;

        public AllergyService(ILogger<AllergyService> logger, IAllergyRepository allergyRepository)
        {
            _logger = logger;
            _allergyRepository = allergyRepository;
        }

        public async Task<ServiceResponse<List<AllergiesGetDto>>> GetAllAllergies()
        {
            var serviceResponse = new ServiceResponse<List<AllergiesGetDto>>();

            try
            {
                serviceResponse.Data = await _allergyRepository.GetAllAllergies();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener las Alergias - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AllergyCategoriesGetDto>>> GetAllAllergyCategories()
        {
            var serviceResponse = new ServiceResponse<List<AllergyCategoriesGetDto>>();

            try
            {
                serviceResponse.Data = await _allergyRepository.GetAllAllergyCategories();
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
