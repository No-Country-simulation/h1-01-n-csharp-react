using AutoMapper;
using Domain.Entities.Medical;
using DTOs.Appointment;
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
    public class AppointmentRepository : GenericRepository<Appointment, int>, IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AppointmentGetDto>> GetMedicAppointments(int medicId)
        {
            var appointments = await Entities
                    .Where(a => a.MedicId == medicId)
                    .Include(x => x.Medic)
                        .ThenInclude(x => x.Specialty)
                    .Include(x => x.MedRecord)
                        .ThenInclude(x => x.Patient)
                    .Where(a => !a.MedRecord.Patient.ApplicationUser.IsDeleted)
                    .ToListAsync();
                    
            
            return _mapper.Map<List<AppointmentGetDto>>(appointments);
        }
    }
}
