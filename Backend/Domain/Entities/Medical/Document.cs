using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class Document : BaseEntity<int>
    {
        public string DocSrc { get; set; }
        public string Description { get; set; } = string.Empty;

        public Treatment Treatment { get; set; }
        public int TreatmentId { get; set; }
    }
}
