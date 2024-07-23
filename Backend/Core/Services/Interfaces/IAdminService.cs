using DTOs.Medic;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Patient;

namespace Core.Services.Interfaces
{
    public interface IAdminService
    {
        Task<ServiceResponse<List<MedicGetDto>>> GetAllMedicUsers();
        Task<ServiceResponse<List<PatientGetDto>>> GetAllPatientUsers();
        Task<ServiceResponse<DeleteResponse>> SoftDeleteUser(string email);
    }
}
