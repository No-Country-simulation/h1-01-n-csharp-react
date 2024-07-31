using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class MedRecordPathology : BaseEntity<int>
    {
        public bool IsActive { get; set; }
        public string CreatorName { get; set; }
        public string CreatorSpecialty { get; set; }

        public MedRecord MedRecord { get; set; }
        public int MedRecordId { get; set; }
        public Pathology Pathology { get; set; }
        public int PathologyId { get; set; }
    }
}
