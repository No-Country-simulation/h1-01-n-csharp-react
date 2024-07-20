using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Transplants
{
    public class Organ : BaseEntity<int>
    {
        public string OrganType { get; set; }

        public List<Donor> Donors { get; set; }
        public List<Recipient> Recipients { get; set; }
    }
}
