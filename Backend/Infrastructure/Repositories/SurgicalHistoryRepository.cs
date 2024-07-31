using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Medical;
using DTOs.Surgical;
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
    public class SurgicalHistoryRepository : GenericRepository<SurgicalHistory, int>, ISurgicalHistoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SurgicalHistoryRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SurgeryTypesGetDto>> GetAllSurgeryTypes()
        {
            var types = await _context.SurgeryTypes
                    .ProjectTo<SurgeryTypesGetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return types;
        }
    }
}
