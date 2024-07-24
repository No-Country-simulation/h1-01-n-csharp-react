using Core.Services;
using Core.Services.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using DTOs.Medicine;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet("GetAllMedicines")]
        public async Task<ActionResult<ServiceResponse<List<MedicineGetDto>>>> GetAllMedicines()
        {
            return Ok(await _medicineService.GetAllMedicines());
        }
    }
}
