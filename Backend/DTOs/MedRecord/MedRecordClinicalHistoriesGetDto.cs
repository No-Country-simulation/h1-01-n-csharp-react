using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.MedRecord
{
    public class MedRecordClinicalHistoriesGetDto
    {
        public int Id { get; set; }
        public string MedicName { get; set; }
        public string Details { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public string CreatorName { get; set; }
        public string CreatorSpecialty { get; set; }
        public string PathologyName { get; set; }
        public string PathologyCategory { get; set; }
        public string Color { get; set; }
    }
}
