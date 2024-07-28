using Core.Services.Interfaces;
using DTOs.Register;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DTOs.Medic;
using Microsoft.AspNetCore.Identity;
using Domain.Entities.Users;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMedicPatientService _medicPatientService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientController(
            IPatientService patientService,
            UserManager<ApplicationUser> userManager,
            IMedicPatientService medicPatientService)
        {
            _patientService = patientService;
            _userManager = userManager;
            _medicPatientService = medicPatientService;
        }

        private async Task<int> GetCurrentPatientUserId()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");
            if (claim != null)
            {
                var user = await _userManager.FindByIdAsync(claim.Value);

                if (user.PatientId.HasValue)
                {

                    return user.PatientId.Value;
                }
                else
                {
                    throw new Exception("El Usuario actual no es un Paciente.");
                }

            }
            else
            {
                throw new Exception("El Claim no es válido.");
            }
        }

        [HttpPost("RegisterPatientUser")]
        public async Task<ActionResult<ServiceResponse<RegisterResponse>>> RegisterPatientUser(RegisterPatientRequest request)
        {
            return Ok(await _patientService.RegisterPatientUser(request));
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("GetPatientMedics")]
        public async Task<ActionResult<ServiceResponse<List<PatientMedicsGetDto>>>> GetPatientMedics()
        {
            var patientId = await GetCurrentPatientUserId();

            return Ok(await _medicPatientService.GetPatientMedics(patientId));
        }
    }
}
