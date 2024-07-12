using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.Models.Entities.Users
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Admin? Admin { get; set; }
        public Guid AdminId { get; set; }
        public Medic? Medic { get; set; }
        public Guid MedicId { get; set; }
        public Patient? Patient { get; set; }
        public Guid PatientId { get; set; }
        public Healthcare Healthcare { get; set; }
        public Guid HealthcareId { get; set; }
        public Lab? Lab { get; set; }
        public Guid LabId { get; set; }
        public GovEnt? GovEnt { get; set; }
        public Guid GovEntId { get; set; }

        public string Location { get; set; } = string.Empty;
    }
}
