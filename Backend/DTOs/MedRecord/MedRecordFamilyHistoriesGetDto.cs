using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.MedRecord
{
    public class MedRecordFamilyHistoriesGetDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string FamilyRelation { get; set; }
        public List<MedRecordPathologiesGetDto> Pathologies { get; set; }
    }
}
