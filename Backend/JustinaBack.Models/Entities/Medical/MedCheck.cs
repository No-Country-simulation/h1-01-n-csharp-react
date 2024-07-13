using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Medical
{
    public class MedCheck : BaseEntity<Guid>
    {
        public DateTime Date { get; set; }
        public bool Taken { get; set; }

        public Treatment Treatment { get; set; }
        public Guid TreatmentId { get; set; }
    }
}
