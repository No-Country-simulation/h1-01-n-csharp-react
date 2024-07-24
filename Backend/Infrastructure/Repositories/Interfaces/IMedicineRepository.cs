using Domain.Entities.Medical;
using DTOs.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IMedicineRepository : IGenericRepository<Medicine, int>
    {
        Task<List<MedicineGetDto>> GetAllMedicines();
    }
}
