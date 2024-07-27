using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class PatientRepository : GenericRepository<Patient, int>, IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PatientRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PatientGetDto>> GetAllPatientUsers()
        {
            var patients = await Entities
                    .Where(p => !p.ApplicationUser.IsDeleted)
                    .ProjectTo<PatientGetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return patients;
        }

        public async Task<List<PatientEmailGetDto>> GetPatientsEmail(string email)
        {
            var patients = await Entities
                    .Where(p => !p.ApplicationUser.IsDeleted && p.ApplicationUser.Email.ToLower().Contains(email.ToLower()))
                    .ProjectTo<PatientEmailGetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return patients;
        }

        public async Task<bool> FindDNIInPatients(string DNI)
        {
            return await Entities
                .AnyAsync(patient => patient.DNI == DNI);
        }
    }
}
