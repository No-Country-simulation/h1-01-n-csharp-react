using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class Appointment : BaseEntity<int>
    {
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public bool IsActive { get; set; }

        public Medic Medic { get; set; }
        public int MedicId { get; set; }
        public MedRecord MedRecord { get; set; }
        public int MedRecordId { get; set; }
    }

    public enum AppointmentType
    {
        Consultation,
        Surgery,
        FollowUp
    }
}
