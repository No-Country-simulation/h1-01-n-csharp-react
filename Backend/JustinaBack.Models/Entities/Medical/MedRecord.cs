using JustinaBack.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Medical
{
    public class MedRecord : BaseEntity<int>
    {
        public string Details { get; set; }

        public Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
