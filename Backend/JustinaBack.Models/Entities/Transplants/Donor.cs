using JustinaBack.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Transplants
{
    public class Donor : BaseEntity<Guid>
    {
        public string OrganSize { get; set; }
        public string Details { get; set; }

        public Patient Patient { get; set; }
        public Guid PatientId { get; set; }
        public Organ Organ { get; set; }
        public Guid OrganId { get; set; }
        public Transplant? Transplant { get; set; }
        public Guid? TransplantId { get; set; }
    }
}
