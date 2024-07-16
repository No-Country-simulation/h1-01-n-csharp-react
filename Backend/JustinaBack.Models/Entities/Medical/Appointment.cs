using JustinaBack.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Medical
{
    public class Appointment : BaseEntity<int>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Medic Medic { get; set; }
        public int MedicId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
    }

    public enum AppointmentType
    {
        Consultation,
        Surgery,
        FollowUp
    }
}
