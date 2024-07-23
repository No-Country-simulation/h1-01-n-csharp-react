using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Users;
using DTOs.Medic;
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
    public class MedicRepository : GenericRepository<Medic, int>, IMedicRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public MedicRepository(IMapper mapper, ApplicationDbContext context) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<MedicGetDto>> GetAllMedicUsersWithSpecialties()
        {
            var medics = await Entities
                    .ProjectTo<MedicGetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return medics;
        }
    }
}
