using DTOs.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Treatment
{
    public class TreatmentAddDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PathologyId { get; set; }
        public List<MedDosageAddDto> MedDosages { get; set; }
    }
}
