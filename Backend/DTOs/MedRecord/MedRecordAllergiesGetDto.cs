using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.MedRecord
{
    public class MedRecordAllergiesGetDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
    }
}
