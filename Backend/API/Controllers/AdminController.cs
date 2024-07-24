﻿using Core.Services.Interfaces;
using DTOs.Medic;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Medical;

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

        [HttpDelete("SoftDeleteUser/{email}")]
        public async Task<ActionResult<ServiceResponse<DeleteResponse>>> SoftDeleteUser(string email)
        {
            return Ok(await _adminService.SoftDeleteUser(email));
        }
    }
}