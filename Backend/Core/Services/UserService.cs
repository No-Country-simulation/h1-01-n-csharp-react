using Domain.Entities.Users;
using DTOs.Medic;
using DTOs.Patient;
using DTOs.User;
using DTOs;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IMedicRepository _medicRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(
            ILogger<UserService> logger,
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

        public async Task<ServiceResponse<List<DeletedUserGetDto>>> GetDeletedUsers()
        {
            var serviceResponse = new ServiceResponse<List<DeletedUserGetDto>>();

            try
            {
                serviceResponse.Data = await _userRepository.GetDeletedUsers();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener Usuarios eliminados - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> SoftDeleteUser(string email)
        {
            var serviceResponse = new ServiceResponse<bool>();

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

        public async Task<ServiceResponse<bool>> HardDeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null || !user.IsDeleted)
                    throw new KeyNotFoundException($"Usuario no encontrado o no marcado para eliminar.");


                switch (user)
                {
                    case { MedicId: not null }:
                        var medicId = user.MedicId.Value;
                        _userRepository.Delete(user);
                        await _medicRepository.Delete(medicId);
                        break;

                    case { PatientId: not null }:
                        var patientId = user.PatientId.Value;
                        _userRepository.Delete(user);
                        await _patientRepository.Delete(patientId);
                        break;

                    default:
                        throw new InvalidOperationException("El usuario no tiene un MedicId o PatientId asignado.");
                }

                await _userRepository.SaveChangesAsync();

                serviceResponse.Message = $"Usuario eliminado definitivamente.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al eliminar usuario - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> RestoreDeletedUser(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null || !user.IsDeleted)
                {
                    throw new KeyNotFoundException($"Usuario no encontrado o no ha sido eliminado.");
                }

                user.IsDeleted = false;
                _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();

                serviceResponse.Message = $"Usuario restaurado.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al restaurar usuario - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
