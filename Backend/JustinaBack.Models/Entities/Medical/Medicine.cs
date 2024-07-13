using JustinaBack.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Medical
{
    public class Medicine : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Lab> Labs { get; set; }
        public List<MedDosage> MedDosages { get; set; }
    }
}
