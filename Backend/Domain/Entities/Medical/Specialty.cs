using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class Specialty : BaseEntity<int>
    {
        public string Type { get; set; }

        public List<Medic> Medics { get; set; }
    }
}
