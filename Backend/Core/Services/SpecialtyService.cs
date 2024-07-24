using Core.Services.Interfaces;
using DTOs.Pathology;
using DTOs;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Specialty;

namespace Core.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ILogger<SpecialtyService> _logger;
        private readonly ISpecialtyRepository _specialtyRepository;

        public SpecialtyService(
            ILogger<SpecialtyService> logger,
            ISpecialtyRepository specialtyRepository)
        {
            _logger = logger;
            _specialtyRepository = specialtyRepository;
        }

        public async Task<ServiceResponse<List<SpecialtyGetDto>>> GetAllSpecialties()
        {
            var serviceResponse = new ServiceResponse<List<SpecialtyGetDto>>();

            try
            {
                serviceResponse.Data = await _specialtyRepository.GetAllSpecialties();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener Especialidades Médicas - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
