using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Appointment
{
    public class AppointmentGetDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public string AppointmentType { get; set; }
        public bool IsActive { get; set; }
        public string MedicName { get; set; }
        public string MedicSpecialty { get; set; }
        public string PatientName { get; set; }
    }
}
