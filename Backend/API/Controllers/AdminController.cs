using Core.Services.Interfaces;
using DTOs.Medic;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Medical;
using DTOs.User;

namespace API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("GetAllMedics")]
        public async Task<ActionResult<ServiceResponse<List<MedicGetDto>>>> GetAllMedicUsers()
        {
            return Ok(await _adminService.GetAllMedicUsers());
        }

        [HttpGet("GetAllPatients")]
        public async Task<ActionResult<ServiceResponse<List<MedicGetDto>>>> GetAllPatientUsers()
        {
            return Ok(await _adminService.GetAllPatientUsers());
        }

        [HttpGet("GetDeletedUsers")]
        public async Task<ActionResult<ServiceResponse<List<DeletedUserGetDto>>>> GetDeletedUsers()
        {
            return Ok(await _adminService.GetDeletedUsers());
        }

        [HttpDelete("SoftDeleteUser/{email}")]
        public async Task<ActionResult<ServiceResponse<DeleteResponse>>> SoftDeleteUser(string email)
        {
            return Ok(await _adminService.SoftDeleteUser(email));
        }

        [HttpDelete("HardDeleteUser/{id}")]
        public async Task<ActionResult<ServiceResponse<DeleteResponse>>> HardDeleteUser(int id)
        {
            return Ok(await _adminService.HardDeleteUser(id));
        }

        [HttpPatch("RestoreUser/{id}")]
        public async Task<ActionResult<ServiceResponse<object>>> RestoreDeletedUser(int id)
        {
            return Ok(await _adminService.RestoreDeletedUser(id));
        }
    }
}
