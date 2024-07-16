using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Medical
{
    public class Document : BaseEntity<int>
    {
        public string DocSrc { get; set; }
        public string Description { get; set; } = string.Empty;

        public MedRecord MedRecord { get; set; }
        public int MedRecordId { get; set; }
    }
}
