using JustinaBack.Models.Entities.Medical;
using JustinaBack.Models.Entities.Transplants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Users
{
    public class Patient : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DNI { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsManagedByParent { get; set; }
        public BloodType BloodType { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public MedRecord? MedRecord { get; set; }
        public Guid? MedRecordId { get; set; }
        public Healthcare? Healthcare { get; set; }
        public Guid? HealthcareId { get; set; }
        public Pathology? Pathology { get; set; }
        public Guid? PathologyId { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<Medic> Medics { get; set; }
        public List<Appointment> Appointments { get; set; }

        //Transplant
        public Donor? Donor { get; set; }
        public Guid? DonorId { get; set; }
        public Recipient? Recipient { get; set; }
        public Guid? RecipientId { get; set; }
    }

    public enum BloodType
    {
        APositive,
        ANegative,
        BPositive,
        BNegative,
        ABPositive,
        ABNegative,
        OPositive,
        ONegative

    }
}
