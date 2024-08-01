using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.MedRecord
{
    public class MedRecordAddDto
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public bool IsAlcoholic { get; set; }
        public bool IsSmoker { get; set; }
        public bool UsesDrugs { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
