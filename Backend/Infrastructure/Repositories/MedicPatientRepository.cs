using Domain.Entities.Users;
using DTOs.Patient;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MedicPatientRepository : GenericRepository<MedicPatient, int>, IMedicPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicPatientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MedicPatient> FindRelationship(int medicId, int patientId)
        {
            var relationship = await Entities
                .Where(r => r.MedicId == medicId && r.PatientId == patientId)
                .FirstOrDefaultAsync();

            return relationship;
        }
    }
}
