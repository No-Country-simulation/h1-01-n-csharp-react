using DTOs;
using DTOs.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IMedicPatientService
    {
        Task<ServiceResponse<bool>> AddRelationshipWithPatient(int medicId, string patientEmail);
        Task<ServiceResponse<List<MedicPatientsGetDto>>> GetMedicPatients(int id);
    }
}
