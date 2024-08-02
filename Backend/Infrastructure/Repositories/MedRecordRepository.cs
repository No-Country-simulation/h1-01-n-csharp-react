using AutoMapper;
using Domain.Entities.Medical;
using DTOs.MedRecord;
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
    public class MedRecordRepository : GenericRepository<MedRecord, int>, IMedRecordRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MedRecordRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MedRecordGetDto> GetMedRecordWithAllHistories(int recordId)
        {
            var record = await Entities
                .Where(x => x.Id == recordId)
                .Include(x => x.Patient)
                    .ThenInclude(x => x.ApplicationUser)
                .Include(x => x.MedRecordAllergies)
                    .ThenInclude(mra => mra.Allergy)
                        .ThenInclude(a => a.AllergyCategory)
                .Include(x => x.FamilyHistories)
                    .ThenInclude(fh => fh.FamilyHistoryPathologies)
                        .ThenInclude(fhp => fhp.Pathology)
                            .ThenInclude(p => p.PathologyCategory)
                .Include(x => x.SurgicalHistories)
                    .ThenInclude(sh => sh.SurgeryType)
                .Include(x => x.ClinicalHistories)
                    .ThenInclude(ch => ch.Pathology)
                        .ThenInclude(p => p.PathologyCategory)
                .FirstOrDefaultAsync();

            return _mapper.Map<MedRecordGetDto>(record);
        }
    }
}
