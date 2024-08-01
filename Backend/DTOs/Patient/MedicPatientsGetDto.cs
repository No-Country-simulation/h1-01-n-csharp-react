using DTOs.Pathology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Patient
{
    public class MedicPatientsGetDto
    {
        public int Id { get; set; }
        public int? MedRecordId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string ParentName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string BloodType { get; set; }
        public string ImgSrc { get; set; } = string.Empty;
    }
}
