using JustinaBack.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Medical
{
    public class Appointment : BaseEntity<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Medic Medic { get; set; }
        public Guid MedicId { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }
    }

    public enum AppointmentType
    {
        Consultation,
        Surgery,
        FollowUp
    }
}
