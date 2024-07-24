using DTOs.Medicine;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IMedicineService
    {
        Task<ServiceResponse<List<MedicineGetDto>>> GetAllMedicines();
    }
}
