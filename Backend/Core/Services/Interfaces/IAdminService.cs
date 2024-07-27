using DTOs.Medic;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Patient;
using DTOs.User;

namespace Core.Services.Interfaces
{
    public interface IAdminService
    {
        Task<ServiceResponse<List<MedicGetDto>>> GetAllMedicUsers();
        Task<ServiceResponse<List<PatientGetDto>>> GetAllPatientUsers();
        Task<ServiceResponse<List<DeletedUserGetDto>>> GetDeletedUsers();
        Task<ServiceResponse<bool>> SoftDeleteUser(string email);
        Task<ServiceResponse<bool>> HardDeleteUser(int id);
        Task<ServiceResponse<bool>> RestoreDeletedUser(int id);
    }
}
