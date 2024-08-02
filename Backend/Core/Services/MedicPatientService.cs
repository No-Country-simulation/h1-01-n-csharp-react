using Azure.Core;
using Core.Services.Interfaces;
using Domain.Entities.Users;
using DTOs;
using DTOs.Medic;
using DTOs.Patient;
using DTOs.Register;
using Infrastructure.Repositories;
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
    public class MedicPatientService : IMedicPatientService
    {
        private readonly ILogger<MedicPatientService> _logger;
        private readonly IMedicPatientRepository _medicPatientRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMedicRepository _medicRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public MedicPatientService(
            ILogger<MedicPatientService> logger,
            IMedicPatientRepository medicPatientRepository,
            UserManager<ApplicationUser> userManager,
            IPatientRepository patientRepository,
            IMedicRepository medicRepository)
        {
            _logger = logger;
            _medicPatientRepository = medicPatientRepository;
            _userManager = userManager;
            _patientRepository = patientRepository;
            _medicRepository = medicRepository;
        }

        public async Task<ServiceResponse<bool>> AddRelationshipWithPatient(int medicId, string patientEmail)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {

                var user = await _userManager.FindByEmailAsync(patientEmail);
                if (user == null || user.PatientId == null)
                {
                    throw new KeyNotFoundException("Usuario no encontrado o no es un paciente.");
                }

                var existingRelationship = await _medicPatientRepository.FindRelationship(medicId, user.PatientId.Value);
                if (existingRelationship != null) throw new Exception("Ya existe una relación con este usuario.");

                var medicPatient = new MedicPatient
                {
                    MedicId = medicId,
                    PatientId = user.PatientId.Value
                };

                await _medicPatientRepository.Insert(medicPatient);
                await _medicPatientRepository.SaveChangesAsync();

                serviceResponse.Data = true;
                serviceResponse.Message = "Relación entre médico y paciente agregada con éxito.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al agregar nueva relación con Paciente - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteRelationshipWithPatient(int medicId, string patientEmail)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {

                var user = await _userManager.FindByEmailAsync(patientEmail);
                if (user == null || user.PatientId == null)
                {
                    throw new KeyNotFoundException("Usuario no encontrado o no es un paciente.");
                }

                var existingRelationship = await _medicPatientRepository.FindRelationship(medicId, user.PatientId.Value);
                if (existingRelationship == null) throw new Exception("No existe una relación con este usuario.");


                _medicPatientRepository.Delete(existingRelationship);
                await _medicPatientRepository.SaveChangesAsync();

                serviceResponse.Data = true;
                serviceResponse.Message = "Relación entre médico y paciente eliminada con éxito.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al eliminar relación con Paciente - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MedicPatientsGetDto>>> GetMedicPatients(int id)
        {
            var serviceResponse = new ServiceResponse<List<MedicPatientsGetDto>>();

            try
            {
                serviceResponse.Data = await _patientRepository.GetMedicPatients(id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener Pacientes - {ex.Message}");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PatientMedicsGetDto>>> GetPatientMedics(int id)
        {
            var serviceResponse = new ServiceResponse<List<PatientMedicsGetDto>>();

            try
            {
                serviceResponse.Data = await _medicRepository.GetPatientMedics(id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, $"Error al obtener Médicos - {ex.Message}");
            }

            return serviceResponse;
        }
    }
}
