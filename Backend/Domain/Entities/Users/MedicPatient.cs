using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class MedicPatient : BaseEntity<int>
    {
        public int MedicId { get; set; }
        public Medic Medic { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
