using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Transplants
{
    public class Donor : BaseEntity<int>
    {
        public string OrganSize { get; set; }
        public string Details { get; set; }

        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Organ Organ { get; set; }
        public int OrganId { get; set; }
        public List<Transplant> Transplants { get; set; }
    }
}
