using Core.Services.Interfaces;
using DTOs.Register;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("RegisterPatientUser")]
        public async Task<ActionResult<ServiceResponse<RegisterResponse>>> RegisterPatientUser(RegisterPatientRequest request)
        {
            return Ok(await _patientService.RegisterPatientUser(request));
        }
    }
}
