using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ClinicalHistory
{
    public class ClinicalHistoryAddDto
    {
        public string MedicName { get; set; }
        public string Details { get; set; } = string.Empty;
        public DateTime DiagnosisDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int PathologyId { get; set; }
    }
}
