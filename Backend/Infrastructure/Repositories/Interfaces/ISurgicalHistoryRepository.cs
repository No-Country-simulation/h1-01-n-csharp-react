using Domain.Entities.Medical;
using DTOs.Surgical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ISurgicalHistoryRepository : IGenericRepository<SurgicalHistory, int>
    {
        Task<List<SurgeryTypesGetDto>> GetAllSurgeryTypes();
    }
}
