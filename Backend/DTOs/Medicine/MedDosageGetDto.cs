using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Medicine
{
    public class MedDosageGetDto
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string CurrentDosage { get; set; }
        public string Instructions { get; set; }
    }
}
