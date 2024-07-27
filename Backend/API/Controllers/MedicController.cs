using Core.Services.Interfaces;
using Domain.Entities.Users;
using DTOs;
using DTOs.Patient;
using DTOs.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMedicService _medicService;
        private readonly IPatientService _patientService;
        private readonly IMedicPatientService _medicPatientService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MedicController(
            IMedicService medicService,
            IPatientService patientService,
            IMedicPatientService medicPatientService,
            UserManager<ApplicationUser> userManager)
        {
            _medicService = medicService;
            _patientService = patientService;
            _medicPatientService = medicPatientService;
            _userManager = userManager;
        }

        private async Task<int> GetCurrentMedicUserId()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id");
            if (claim != null)
            {
                var user = await _userManager.FindByIdAsync(claim.Value);

                if (user.MedicId.HasValue)
                {

                    return user.MedicId.Value;
                } 
                else
                {
                    throw new Exception("El Usuario actual no es Médico.");
                }

            }
            else
            {
                throw new Exception("El Claim no es válido.");
            }
        }

        [HttpPost("RegisterMedicUser")]
        public async Task<ActionResult<ServiceResponse<RegisterResponse>>> RegisterMedicUser(RegisterMedicRequest request)
        {
            return Ok(await _medicService.RegisterMedicUser(request));
        }

        [Authorize(Roles = "Admin,Medic")]
        [HttpGet("GetPatientsEmail/{email}")]
        public async Task<ActionResult<ServiceResponse<List<PatientEmailGetDto>>>> GetPatientsEmail(string email)
        {
            return Ok(await _patientService.GetPatientsEmail(email));
        }

        [Authorize(Roles = "Medic")]
        [HttpPost("AddRelationshipWithPatient/{patientEmail}")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddRelationshipWithPatient(string patientEmail)
        {
            var medicId = await GetCurrentMedicUserId();

            return Ok(await _medicPatientService.AddRelationshipWithPatient(medicId, patientEmail));
        }

        [Authorize(Roles = "Medic")]
        [HttpGet("GetMedicPatients/{patientEmail}")]
        public async Task<ActionResult<ServiceResponse<bool>>> GetMedicPatients()
        {
            var medicId = await GetCurrentMedicUserId();

            return null;
            //return Ok(await _medicPatientService.AddRelationshipWithPatient(medicId, patientEmail));
        }
    }
}
