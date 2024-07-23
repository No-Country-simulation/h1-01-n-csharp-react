﻿using Azure.Core;
using Core.Behaviors;
using Core.Services.Interfaces;
using Domain.Entities.Medical;
using Domain.Entities.Users;
using DTOs;
using DTOs.Medic;
using DTOs.Patient;
using DTOs.Register;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly ILogger<AdminService> _logger;
        private readonly IMedicRepository _medicRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(
            ILogger<AdminService> logger,
            IMedicRepository medicRepository,
            IPatientRepository patientRepository,
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository)
        {
            _logger = logger;
            _medicRepository = medicRepository;
            _patientRepository = patientRepository;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<List<MedicGetDto>>> GetAllMedicUsers()
        {
            var serviceResponse = new ServiceResponse<List<MedicGetDto>>();

            try
            {
                serviceResponse.Data = await _medicRepository.GetAllMedicUsersWithSpecialties();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener Médicos - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PatientGetDto>>> GetAllPatientUsers()
        {
            var serviceResponse = new ServiceResponse<List<PatientGetDto>>();

            try
            {
                serviceResponse.Data = await _patientRepository.GetAllPatientUsers();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener Pacientes - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<DeleteResponse>> SoftDeleteUser(string email)
        {
            var serviceResponse = new ServiceResponse<DeleteResponse>();

            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null || user.IsDeleted)
                {
                    throw new KeyNotFoundException($"Usuario no encontrado o ya eliminado.");
                }

                user.IsDeleted = true;
                _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();

                serviceResponse.Message = $"Usuario marcado como eliminado.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al eliminar usuario - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
