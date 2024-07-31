using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Medical;
using DTOs.Allergy;
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
    public class AllergyRepository : GenericRepository<Allergy, int>, IAllergyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AllergyRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AllergiesGetDto>> GetAllAllergies()
        {
            var allergies = await Entities
                    .Include(a => a.AllergyCategory)
                    .ProjectTo<AllergiesGetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return allergies;
        }

        public async Task<List<AllergyCategoriesGetDto>> GetAllAllergyCategories()
        {
            var categories = await _context.AllergyCategories
                    .ProjectTo<AllergyCategoriesGetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return categories;
        }


    }
}
