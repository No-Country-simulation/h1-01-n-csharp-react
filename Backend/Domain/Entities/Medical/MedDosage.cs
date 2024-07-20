using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class MedDosage : BaseEntity<int>
    {
        public string CurrentDosage { get; set; }
        public string Instructions { get; set; }

        public Medicine Medicine { get; set; }
        public int MedicineId { get; set; }
        public Treatment Treatment { get; set; }
        public int TreatmentId { get; set; }
    }
}
