using Domain.Entities.Users;
using DTOs.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient, int>
    {
        Task<List<PatientGetDto>> GetAllPatientUsers();
    }
}
