using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Medical;
using DTOs.Pathology;
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
    public class PathologyRepository : GenericRepository<Pathology, int>, IPathologyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PathologyRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PathologyGetDto>> GetAllPathologies()
        {
            var pathologies = await Entities
                    .Include(p => p.PathologyCategory)
                    .ProjectTo<PathologyGetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return pathologies;
        }

        public async Task<List<PathologyCategoriesGetDto>> GetAllPathologyCategories()
        {
            var categories = await _context.PathologyCategories
                    .ProjectTo<PathologyCategoriesGetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return categories;
        }
    }
}
