using DTOs.Allergy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.MedRecord
{
    public class MedRecordGetDto
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public bool IsAlcoholic { get; set; }
        public bool IsSmoker { get; set; }
        public bool UsesDrugs { get; set; }
        public string Note { get; set; } = string.Empty;

        public List<MedRecordAllergiesGetDto> MedRecordAllergies { get; set; }
        public List<MedRecordPathologiesGetDto> MedRecordPathologies { get; set; }
        public List<MedRecordFamilyHistoriesGetDto> FamilyHistories { get; set; }
        public List<MedRecordSurgicalHistoriesGetDto> SurgicalHistories { get; set; }
        public List<MedRecordClinicalHistoriesGetDto> ClinicalHistories { get; set; }
    }
}
