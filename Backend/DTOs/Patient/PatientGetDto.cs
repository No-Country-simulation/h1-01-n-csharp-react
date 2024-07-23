using Domain.Entities.Users;
using DTOs.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs.Patient
{
    public class PatientGetDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public bool IsManagedByParent { get; set; } = false;
        public string ParentName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string BloodType { get; set; }
        public string Email { get; set; } = string.Empty;

    }
}
