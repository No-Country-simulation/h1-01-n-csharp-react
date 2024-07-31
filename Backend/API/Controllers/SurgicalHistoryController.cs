using Core.Services.Interfaces;
using DTOs;
using DTOs.Surgical;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgicalHistoryController : ControllerBase
    {
        private readonly ISurgicalHistoryService _surgicalHistoryService;

        public SurgicalHistoryController(ISurgicalHistoryService surgicalHistoryService)
        {
            _surgicalHistoryService = surgicalHistoryService;
        }

        [HttpGet("GetAllSurgeryTypes")]
        public async Task<ActionResult<ServiceResponse<List<SurgeryTypesGetDto>>>> GetAllSurgeryTypes()
        {
            return Ok(await _surgicalHistoryService.GetAllSurgeryTypes());
        }


    }
}
