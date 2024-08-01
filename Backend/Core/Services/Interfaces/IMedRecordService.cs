using DTOs;
using DTOs.MedRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IMedRecordService
    {
        Task<ServiceResponse<bool>> AddMedRecordToPatient(int medicId, int patientId, MedRecordAddDto request);
        Task<ServiceResponse<MedRecordGetDto>> GetPatientMedRecord(int medicId, int patientId);
    }
}
