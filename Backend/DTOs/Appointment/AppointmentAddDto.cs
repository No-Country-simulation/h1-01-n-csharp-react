using Domain.Entities.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Appointment
{
    public class AppointmentAddDto
    {
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
