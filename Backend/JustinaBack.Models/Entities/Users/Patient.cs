using JustinaBack.Models.Entities.Medical;
using JustinaBack.Models.Entities.Transplants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Users
{
    public class Patient : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DNI { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsManagedByParent { get; set; }
        public BloodType BloodType { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public MedRecord? MedRecord { get; set; }
        public int? MedRecordId { get; set; }
        public Healthcare? Healthcare { get; set; }
        public int? HealthcareId { get; set; }
        public Pathology? Pathology { get; set; }
        public int? PathologyId { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<Medic> Medics { get; set; }
        public List<Appointment> Appointments { get; set; }

        //Transplant
        public Donor? Donor { get; set; }
        public int? DonorId { get; set; }
        public Recipient? Recipient { get; set; }
        public int? RecipientId { get; set; }
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
