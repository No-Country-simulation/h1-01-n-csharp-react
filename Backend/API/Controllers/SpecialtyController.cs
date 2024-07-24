using Core.Services;
using Core.Services.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using DTOs.Specialty;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtyController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        [HttpGet("GetAllSpecialties")]
        public async Task<ActionResult<ServiceResponse<List<SpecialtyGetDto>>>> GetAllSpecialties()
        {
            return Ok(await _specialtyService.GetAllSpecialties());
        }
    }
}
