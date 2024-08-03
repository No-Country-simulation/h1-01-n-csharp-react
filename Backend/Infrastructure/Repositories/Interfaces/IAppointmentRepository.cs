using Domain.Entities.Medical;
using DTOs.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment, int>
    {
        Task<List<AppointmentGetDto>> GetMedicAppointments(int medicId);
    }
}
