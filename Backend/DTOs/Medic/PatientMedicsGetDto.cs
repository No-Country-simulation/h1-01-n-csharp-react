using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Medic
{
    public class PatientMedicsGetDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DNI { get; set; }
        public string License { get; set; }
        public string About { get; set; } = string.Empty;
        public string ImgSrc { get; set; } = string.Empty;
        public string Specialty { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
