using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class ApplicationUser : IdentityUser<int>
    {
        public Admin? Admin { get; set; }
        public int? AdminId { get; set; }
        public Medic? Medic { get; set; }
        public int? MedicId { get; set; }
        public Patient? Patient { get; set; }
        public int? PatientId { get; set; }
        public Healthcare? Healthcare { get; set; }
        public int? HealthcareId { get; set; }
        public Lab? Lab { get; set; }
        public int? LabId { get; set; }
        public GovEnt? GovEnt { get; set; }
        public int? GovEntId { get; set; }

        public string Address { get; set; } = string.Empty;
    }
}
