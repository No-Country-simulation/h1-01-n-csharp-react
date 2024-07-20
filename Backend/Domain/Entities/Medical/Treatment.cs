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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool InProgress { get; set; }

        public Pathology Pathology { get; set; }
        public int PathologyId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public List<MedDosage> MedDosages { get; set; }
        public List<MedCheck> MedChecks { get; set; }
        public List<Document> Documents { get; set; }
    }
}
