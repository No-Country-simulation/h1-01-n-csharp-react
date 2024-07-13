using JustinaBack.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Medical
{
    public class Specialty : BaseEntity<Guid>
    {
        public string Type { get; set; }

        public List<Medic> Medics { get; set; }
    }
}
