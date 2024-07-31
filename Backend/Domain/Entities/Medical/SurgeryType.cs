using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class SurgeryType : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<SurgicalHistory> SurgicalHistories { get; set; }
    }
}
