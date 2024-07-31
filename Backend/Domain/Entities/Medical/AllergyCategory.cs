using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class AllergyCategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public List<Allergy> Allergies { get; set; }
    }
}
