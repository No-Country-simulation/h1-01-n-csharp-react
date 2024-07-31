using Domain.Entities.Medical;
using DTOs.Allergy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IAllergyRepository : IGenericRepository<Allergy, int>
    {
        Task<List<AllergiesGetDto>> GetAllAllergies();
        Task<List<AllergyCategoriesGetDto>> GetAllAllergyCategories();
    }
}
