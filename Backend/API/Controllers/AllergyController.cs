using Core.Services;
using Core.Services.Interfaces;
using DTOs.Pathology;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DTOs.Allergy;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyService _allergyService;

        public AllergyController(IAllergyService allergyService)
        {
            _allergyService = allergyService;
        }

        [HttpGet("GetAllAllergies")]
        public async Task<ActionResult<ServiceResponse<List<AllergiesGetDto>>>> GetAllAllergies()
        {
            return Ok(await _allergyService.GetAllAllergies());
        }

        [HttpGet("GetAllAllergyCategories")]
        public async Task<ActionResult<ServiceResponse<List<AllergyCategoriesGetDto>>>> GetAllAllergyCategories()
        {
            return Ok(await _allergyService.GetAllAllergyCategories());
        }
    }
}
