using Domain.Entities.Medical;
using DTOs.MedRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IMedRecordRepository : IGenericRepository<MedRecord, int>
    {
        Task<MedRecordGetDto> GetMedRecordWithAllHistories(int recordId);
    }
}
