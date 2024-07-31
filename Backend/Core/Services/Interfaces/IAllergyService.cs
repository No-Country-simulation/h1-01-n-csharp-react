using DTOs.Allergy;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IAllergyService
    {
        Task<ServiceResponse<List<AllergiesGetDto>>> GetAllAllergies();
        Task<ServiceResponse<List<AllergyCategoriesGetDto>>> GetAllAllergyCategories();
    }
}
