using DTOs;
using DTOs.Medic;
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
        Task<ServiceResponse<bool>> DeleteRelationshipWithPatient(int medicId, string patientEmail);
        //Task<ServiceResponse<List<MedicPatientsGetDto>>> GetMedicPatients(int id);
        Task<ServiceResponse<List<PatientMedicsGetDto>>> GetPatientMedics(int id);
    }
}
