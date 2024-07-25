using DTOs.Register;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Patient;

namespace Core.Services.Interfaces
{
    public interface IPatientService
    {
        Task<ServiceResponse<RegisterResponse>> RegisterPatientUser(RegisterPatientRequest request);
        Task<ServiceResponse<List<PatientEmailGetDto>>> GetPatientsEmail(string email);
    }
}
