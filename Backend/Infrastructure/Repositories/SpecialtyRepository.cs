using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Medical;
using DTOs.Specialty;
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
    public class SpecialtyRepository : GenericRepository<Specialty, int>, ISpecialtyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SpecialtyRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SpecialtyGetDto>> GetAllSpecialties()
        {
            var specialties = await Entities
                    .ProjectTo<SpecialtyGetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return specialties;
        }
    }
}
