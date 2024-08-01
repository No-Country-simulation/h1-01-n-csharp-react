using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs.Register
{
    public class RegisterMedicRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DNI { get; set; }
        public string License { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int SpecialtyId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string ImgSrc { get; set; } = string.Empty;
        [JsonIgnore]
        public UserRoles UserType { get; set; } = UserRoles.Medic;

    }
}
