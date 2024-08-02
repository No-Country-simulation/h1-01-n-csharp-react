using DTOs.Pathology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ClinicalHistory
{
    public class ClinicalHistoryGetDto
    {
        public int Id { get; set; }
        public string MedicName { get; set; }
        public string Details { get; set; } = string.Empty;
        public DateTime DiagnosisDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string CreatorName { get; set; }
        public string CreatorSpecialty { get; set; }

        public RecordPathologyGetDto RecordPathology { get; set; }
    }
}
