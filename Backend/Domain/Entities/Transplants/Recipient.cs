using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Transplants
{
    public class Recipient : BaseEntity<int>
    {
        public string RequiredSize { get; set; }
        public string Requirements { get; set; }

        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Organ Organ { get; set; }
        public int OrganId { get; set; }
        public List<Transplant> Transplants { get; set; }
    }
}
