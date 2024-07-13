using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Medical
{
    public class MedDosage : BaseEntity<Guid>
    {
        public string CurrentDosage { get; set; }
        public string Instructions { get; set; }

        public Medicine Medicine { get; set; }
        public Guid MedicineId { get; set; }
        public Treatment Treatment { get; set; }
        public Guid TreatmentId { get; set; }
    }
}
