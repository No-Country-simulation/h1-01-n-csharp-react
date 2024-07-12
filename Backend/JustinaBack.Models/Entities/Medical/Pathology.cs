using JustinaBack.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Medical
{
    public class Pathology : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public List<Patient> Patients { get; set; }
        public List<Treatment> Treatments { get; set; }
    }
}
