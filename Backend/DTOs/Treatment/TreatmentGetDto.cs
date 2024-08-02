using Domain.Entities.Medical;
using DTOs.Document;
using DTOs.Medicine;
using DTOs.Pathology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Treatment
{
    public class TreatmentGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays => (EndDate - StartDate).Days + 1;
        public int AdherenceCounter { get; set; } = 0;
        public int FailedCounter { get; set; } = 0;
        public bool AdherenceCheck { get; set; } = true;
        public DateTime? LastCheckedDay { get; set; }
        public bool CanPressButton { get; set; } = true;
        public bool InProgress { get; set; } = true;
        public string CreatorName { get; set; }
        public string CreatorSpecialty { get; set; }

        public RecordPathologyGetDto TreatmentPathology { get; set; }
        public List<MedDosageGetDto> MedDosages { get; set; }
        public List<DocumentGetDto> Documents { get; set; }
    }
}
