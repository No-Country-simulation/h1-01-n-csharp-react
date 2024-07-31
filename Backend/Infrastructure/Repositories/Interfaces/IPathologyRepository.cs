using Domain.Entities.Medical;
using DTOs.Pathology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IPathologyRepository : IGenericRepository<Pathology, int>
    {
        Task<List<PathologyGetDto>> GetAllPathologies();
        Task<List<PathologyCategoriesGetDto>> GetAllPathologyCategories();
    }
}
