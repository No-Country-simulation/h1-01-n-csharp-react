using AutoMapper;
using Domain.Entities.Medical;
using DTOs.ClinicalHistory;
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
    public class ClinicalHistoryRepository : GenericRepository<ClinicalHistory, int>, IClinicalHistoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClinicalHistoryRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClinicalHistoryGetDto>> GetAllClinicalHistories(int medRecordId)
        {
            var histories = await Entities
                    .Where(ch => ch.MedRecordId == medRecordId && ch.IsActive)
                    .Include(x => x.Pathology)
                        .ThenInclude(x => x.PathologyCategory)
                    .ToListAsync();

            return _mapper.Map<List<ClinicalHistoryGetDto>>(histories);
        }
    }
}
