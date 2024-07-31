using DTOs;
using DTOs.Surgical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ISurgicalHistoryService
    {
        Task<ServiceResponse<List<SurgeryTypesGetDto>>> GetAllSurgeryTypes();
    }
}
