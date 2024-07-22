using Core.Services.Interfaces;
using DTOs;
using DTOs.Register;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMedicService _medicService;

        public MedicController(IMedicService medicService)
        {
            _medicService = medicService;
        }

        [HttpPost("RegisterMedicUser")]
        public async Task<ActionResult<ServiceResponse<RegisterResponse>>> RegisterMedicUser(RegisterMedicRequest request)
        {
            return Ok(await _medicService.RegisterMedicUser(request));
        }
    }
}
