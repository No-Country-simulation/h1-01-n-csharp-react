using Core.Services.Interfaces;
using DTOs;
using DTOs.Patient;
using DTOs.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMedicService _medicService;
        private readonly IPatientService _patientService;

        public MedicController(
            IMedicService medicService,
            IPatientService patientService)
        {
            _medicService = medicService;
            _patientService = patientService;
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
    }
}
