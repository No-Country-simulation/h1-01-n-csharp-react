using DTOs;
using DTOs.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ITreatmentService
    {
        Task<ServiceResponse<bool>> AddTreatmentToPatient(int medicId, string patientEmail, TreatmentAddDto request);
        Task<ServiceResponse<List<TreatmentGetDto>>> GetMedicTreatments(int medicId);
    }
}
