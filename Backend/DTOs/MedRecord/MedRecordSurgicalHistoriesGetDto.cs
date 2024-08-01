using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.MedRecord
{
    public class MedRecordSurgicalHistoriesGetDto
    {
        public int Id { get; set; }
        public string SurgeonName { get; set; }
        public string Hospital { get; set; }
        public string Details { get; set; }
        public DateTime SurgeryDate { get; set; }
        public string CreatorName { get; set; }
        public string CreatorSpecialty { get; set; }
        public string SurgeryType { get; set; }
    }
}
