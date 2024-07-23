using DTOs.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs.Medic
{
    public class MedicGetDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DNI { get; set; }
        public string License { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; } = string.Empty;

    }
}
