using JustinaBack.Models.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Medical
{
    public class Medicine : BaseEntity<int>
    {
        public int CertificateNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Lab> Labs { get; set; }
        public List<MedDosage> MedDosages { get; set; }
    }
}
