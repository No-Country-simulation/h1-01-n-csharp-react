using AutoMapper;
using Domain.Entities.Medical;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
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
    }
}
