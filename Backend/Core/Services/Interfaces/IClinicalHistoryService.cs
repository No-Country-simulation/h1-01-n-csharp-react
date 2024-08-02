using DTOs.ClinicalHistory;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IClinicalHistoryService
    {
        Task<ServiceResponse<bool>> AddClinicalHistory(int medicId, int medRecordId, ClinicalHistoryAddDto request);
        Task<ServiceResponse<List<ClinicalHistoryGetDto>>> GetClinicalHistoriesFromRecord(int medicId, int medRecordId);
    }
}
