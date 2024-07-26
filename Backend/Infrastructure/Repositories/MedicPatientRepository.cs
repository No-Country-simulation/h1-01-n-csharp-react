using Domain.Entities.Users;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
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
    }
}
