using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class FamilyHistory : BaseEntity<int>
    {
        public string Details { get; set; } = string.Empty;
        public FamilyRelation FamilyRelation { get; set; }

        public MedRecord MedRecord { get; set; }
        public int MedRecordId { get; set; }
        public List<FamilyHistoryPathology> FamilyHistoryPathologies { get; set; }
    }

    public enum FamilyRelation
    {
        Father,
        Mother,
        Brother,
        Sister,
        Grandfather,
        Grandmother,
        Uncle,
        Aunt,
        Cousin
    }
}
