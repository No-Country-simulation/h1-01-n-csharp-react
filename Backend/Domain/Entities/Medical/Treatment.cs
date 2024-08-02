using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class Treatment : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays => (EndDate - StartDate).Days + 1;
        public int AdherenceCounter { get; set; } = 0;
        public int FailedCounter { get; set; } = 0;
        public bool AdherenceCheck { get; set; } = true;
        public DateTime LastCheckedDay { get; set; }
        public bool CanPressButton { get; set; } = true;
        public bool InProgress { get; set; }
        public string CreatorName { get; set; }
        public string CreatorSpecialty { get; set; }

        public MedRecord MedRecord { get; set; }
        public int MedRecordId { get; set; }
        public Pathology Pathology { get; set; }
        public int PathologyId { get; set; }
        public List<MedDosage> MedDosages { get; set; }
        public List<Document> Documents { get; set; }
    }
}
