using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class ClinicalHistory : BaseEntity<int>
    {
        public string MedicName { get; set; }
        public string Details { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public string CreatorName { get; set; }
        public string CreatorSpecialty { get; set; }

        public MedRecord MedRecord { get; set; }
        public int MedRecordId { get; set; }
        public Pathology Pathology { get; set; }
        public int PathologyId { get; set; }
    }
}
