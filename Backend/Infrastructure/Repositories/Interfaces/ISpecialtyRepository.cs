using Domain.Entities.Medical;
using DTOs.Specialty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ISpecialtyRepository : IGenericRepository<Specialty, int>
    {
        Task<List<SpecialtyGetDto>> GetAllSpecialties();
    }
}
