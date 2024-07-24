using Core.Services.Interfaces;
using DTOs;
using DTOs.Medicine;
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
    public class MedicineService : IMedicineService
    {
        private readonly ILogger<MedicineService> _logger;
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(
            ILogger<MedicineService> logger,
            IMedicineRepository medicineRepository)
        {
            _logger = logger;
            _medicineRepository = medicineRepository;
        }

        public async Task<ServiceResponse<List<MedicineGetDto>>> GetAllMedicines()
        {
            var serviceResponse = new ServiceResponse<List<MedicineGetDto>>();

            try
            {
                serviceResponse.Data = await _medicineRepository.GetAllMedicines();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener Medicamentos - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
