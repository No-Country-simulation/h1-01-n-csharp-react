using Domain.Entities.Medical;
using DTOs.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface ITreatmentRepository : IGenericRepository<Treatment, int>
    {
        Task<List<TreatmentGetDto>> GetMedicTreatments(int medicId);
    }
}
