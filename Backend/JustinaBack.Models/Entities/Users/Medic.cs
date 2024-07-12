using JustinaBack.Models.Entities.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Users
{
    public class Medic : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; } = string.Empty;
        public string ImgSrc { get; set; } = string.Empty;

        public ApplicationUser ApplicationUser { get; set; }
        public Specialty Specialty { get; set; }
        public Guid SpecialtyId { get; set; }
        public Healthcare? Healthcare { get; set; }
        public Guid? HealthcareId { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Appointment> Appointments { get; set; }
    }

    public enum MedicRole
    {
        PrimaryDoctor,
        Assistant,
    }
}
