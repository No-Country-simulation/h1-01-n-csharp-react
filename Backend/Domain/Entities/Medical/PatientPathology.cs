using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Medical
{
    public class PatientPathology : BaseEntity<int>
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int PathologyId { get; set; }
        public Pathology Pathology { get; set; }

        public bool IsActive { get; set; }
    }
}
