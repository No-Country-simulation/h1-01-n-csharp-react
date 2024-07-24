using Core.Services;
using Core.Services.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using DTOs.Pathology;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathologyController : ControllerBase
    {
        private readonly IPathologyService _pathologyService;

        public PathologyController(IPathologyService pathologyService)
        {
            _pathologyService = pathologyService;
        }

        [HttpGet("GetAllPathologies")]
        public async Task<ActionResult<ServiceResponse<List<PathologyGetDto>>>> GetAllPathologies()
        {
            return Ok(await _pathologyService.GetAllPathologies());
        }
    }
}
