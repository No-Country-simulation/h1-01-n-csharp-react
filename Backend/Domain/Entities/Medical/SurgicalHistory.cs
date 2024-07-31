using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class SurgicalHistory : BaseEntity<int>
    {
        public string SurgeonName { get; set; } = string.Empty;
        public string Hospital { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime SurgeryDate { get; set; }
        public string CreatorName { get; set; }
        public string CreatorSpecialty { get; set; }

        public MedRecord MedRecord { get; set; }
        public int MedRecordId { get; set; }
        public SurgeryType SurgeryType { get; set; }
        public int SurgeryTypeId { get; set; }
    }
}
