using DTOs;
using DTOs.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<ServiceResponse<bool>> AddAppointmentToPatient(int medicId, string patientEmail, AppointmentAddDto request);
        Task<ServiceResponse<List<AppointmentGetDto>>> GetMedicAppointments(int medicId);
    }
}
