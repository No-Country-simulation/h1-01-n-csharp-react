using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs.Register
{
    public class RegisterPatientRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DNI { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public bool IsManagedByParent { get; set; } = false;
        public string ParentName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public BloodType BloodType { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string ImgSrc { get; set; } = string.Empty;
        [JsonIgnore]
        public UserRoles UserType { get; set; } = UserRoles.Patient;
    }
}
