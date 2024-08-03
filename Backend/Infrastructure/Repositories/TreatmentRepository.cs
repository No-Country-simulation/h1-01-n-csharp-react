using AutoMapper;
using Domain.Entities.Medical;
using DTOs.Treatment;
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
    public class TreatmentRepository : GenericRepository<Treatment, int>, ITreatmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TreatmentRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TreatmentGetDto>> GetMedicTreatments(int medicId)
        {
            var treatments = await Entities
                .Include(t => t.MedRecord)
                    .ThenInclude(mr => mr.Patient)
                        .ThenInclude(p => p.MedicPatients)
                .Where(t => t.MedRecord.Patient.MedicPatients.Any(mp => mp.MedicId == medicId))
                .Include(x => x.Pathology)
                    .ThenInclude(x => x.PathologyCategory)
                .Include(x => x.MedDosages)
                    .ThenInclude(x => x.Medicine)
                .Include(x => x.Documents)
                .ToListAsync();

            return _mapper.Map<List<TreatmentGetDto>>(treatments);
        }
    }
}
