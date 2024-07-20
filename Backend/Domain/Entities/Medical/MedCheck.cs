using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class MedCheck : BaseEntity<int>
    {
        public DateTime Date { get; set; }
        public bool Taken { get; set; }

        public Treatment Treatment { get; set; }
        public int TreatmentId { get; set; }
    }
}
