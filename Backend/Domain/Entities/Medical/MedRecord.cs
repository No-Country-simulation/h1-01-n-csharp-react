using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class MedRecord : BaseEntity<int>
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public bool IsAlcoholic { get; set; }
        public bool IsSmoker { get; set; }
        public bool UsesDrugs { get; set; }
        public string Note { get; set; } = string.Empty;

        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public List<MedRecordAllergy> MedRecordAllergies { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<FamilyHistory> FamilyHistories { get; set; }
        public List<SurgicalHistory> SurgicalHistories { get; set; }
        public List<ClinicalHistory> ClinicalHistories { get; set; }
    }
}
