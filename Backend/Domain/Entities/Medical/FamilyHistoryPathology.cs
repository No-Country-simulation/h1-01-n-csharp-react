using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class FamilyHistoryPathology : BaseEntity<int>
    {
        public FamilyHistory FamilyHistory { get; set; }
        public int FamilyHistoryId { get; set; }
        public Pathology Pathology { get; set; }
        public int PathologyId { get; set; }
    }
}
