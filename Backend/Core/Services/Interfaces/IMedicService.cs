using DTOs;
using DTOs.Medic;
using DTOs.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IMedicService
    {
        Task<ServiceResponse<RegisterResponse>> RegisterMedicUser(RegisterMedicRequest request);
        Task<ServiceResponse<PatientMedicsGetDto>> GetMedicUserData(int medicId);
    }
}
