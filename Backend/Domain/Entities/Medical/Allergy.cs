using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class Allergy : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<MedRecordAllergy> MedRecordAllergies { get; set; }
        public AllergyCategory AllergyCategory { get; set; }
        public int AllergyCategoryId { get; set; }
    }
}
