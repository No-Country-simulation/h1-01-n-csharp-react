using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Users
{
    public class Healthcare : BaseEntity<Guid>
    {
        public string ImgSrc = string.Empty;

        public ApplicationUser ApplicationUser { get; set; }
        public List<Medic> Medics { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
