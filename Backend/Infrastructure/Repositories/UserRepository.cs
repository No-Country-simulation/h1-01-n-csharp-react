using Domain.Entities.Users;
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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMedicRepository _medicRepository;
        private readonly IPatientRepository _patientRepository;

        public UserRepository(ApplicationDbContext context,
            IMedicRepository medicRepository,
            IPatientRepository patientRepository)
        {
            _context = context;
            _medicRepository = medicRepository;
            _patientRepository = patientRepository;
        }

        public async Task<bool> IsDNIInUse(string DNI)
        {
            bool isMedic = await _medicRepository.FindDNIInMedics(DNI);
            bool isPatient = await _patientRepository.FindDNIInPatients(DNI);

            return isMedic || isPatient;
        }

        public void Update(ApplicationUser user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
