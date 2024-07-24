using DTOs.Specialty;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ISpecialtyService
    {
        Task<ServiceResponse<List<SpecialtyGetDto>>> GetAllSpecialties();
    }
}
