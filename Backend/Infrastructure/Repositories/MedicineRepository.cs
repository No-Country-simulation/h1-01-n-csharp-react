using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Medical;
using DTOs.Medicine;
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
    public class MedicineRepository : GenericRepository<Medicine, int>, IMedicineRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MedicineRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MedicineGetDto>> GetAllMedicines()
        {
            var medicines = await Entities
                    .ProjectTo<MedicineGetDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            return medicines;
        }
    }
}
