using Domain.Entities.Users;
using DTOs.Medic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IMedicRepository : IGenericRepository<Medic, int>
    {
        Task<List<MedicGetDto>> GetAllMedicUsersWithSpecialties();
    }
}
