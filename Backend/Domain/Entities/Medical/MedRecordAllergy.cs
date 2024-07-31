using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class MedRecordAllergy : BaseEntity<int>
    {
        public bool IsActive { get; set; }

        public MedRecord MedRecord { get; set; }
        public int MedRecordId { get; set; }
        public Allergy Allergy { get; set; }
        public int AllergyId { get; set; }
    }
}
