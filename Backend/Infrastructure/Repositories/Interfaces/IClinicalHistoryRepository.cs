using Domain.Entities.Medical;
using DTOs.ClinicalHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IClinicalHistoryRepository : IGenericRepository<ClinicalHistory, int>
    {
        Task<List<ClinicalHistoryGetDto>> GetAllClinicalHistories(int medRecordId);
    }
}
