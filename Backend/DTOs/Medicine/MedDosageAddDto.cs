using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Medicine
{
    public class MedDosageAddDto
    {
        public string CurrentDosage { get; set; }
        public string Instructions { get; set; }
        public int MedicineId { get; set; }
    }
}
