using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class Pathology : BaseEntity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public List<PatientPathology> PatientPathologies { get; set; }
        public List<Treatment> Treatments { get; set; }
    }
}
