using DTOs.Pathology;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IPathologyService
    {
        Task<ServiceResponse<List<PathologyGetDto>>> GetAllPathologies();
        Task<ServiceResponse<List<PathologyCategoriesGetDto>>> GetAllPathologyCategories();
    }
}
