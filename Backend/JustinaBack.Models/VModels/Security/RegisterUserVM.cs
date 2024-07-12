using System.ComponentModel.DataAnnotations;


namespace JustinaBack.Models
{
    public class RegisterUserVM : RegisterVM
    {
        [Required]
        public long? PhoneNumber { get; set; }

        [Required]
        public bool? IsMale { get; set; }

        [Required]
        public bool? IsSocialLogin { get; set; }
        [Required]
        public int? LoginTypeId { get; set; }

        [Required]
        public string? RFC { get; set; }
        [Required]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4}$", ErrorMessage = "The date format must be DD/MM/YYYY")]
        [DateRange]
        public string? BirthDate { get; set; }

        public string? StreetName { get; set; }
        public string? ExtNumber { get; set; }
        public string? IntNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? References { get; set; }
        // Estado
        public string? State { get; set; }
        // Municipio
        public string? Municipality { get; set; }
        // Colonia
        public string? Suburb { get; set; }
        [Required]
        [AllowedValues(true)]
        public bool? ResponsabilityDisclaimer { get; set; }

        public PhoneEF GetPhone()
        {
            return new PhoneEF
            {
                CountryCode = 52,
                Number = PhoneNumber!.Value,
                IsMobile = true,
                IsMainPhone = true,
            };
        }

        public AddressEF? GetAddress()
        {
            List<string> addressProperties = new List<string> { StreetName, ExtNumber, IntNumber, ZipCode, References, State, Municipality, Suburb };

            bool isValidAddress = addressProperties.Any(prop => !string.IsNullOrWhiteSpace(prop) && !string.IsNullOrEmpty(prop));

            if (isValidAddress)
            {

                var address = new AddressEF
                {
                    StreetName = StreetName,
                    ExtNumber = ExtNumber,
                    IntNumber = IntNumber,
                    ZipCode = ZipCode,
                    References = References,
                    State = State,
                    Municipality = Municipality,
                    Suburb = Suburb
                };

                address.DisplayName = address.FullAddress;

                return address;
            }

            return null;
        }

        public ContactEF GetContact()
        {
            string dateFormat = "dd/MM/yyyy";

            var contact = new ContactEF
            {
                EntityPublicKey = Guid.NewGuid(),
                FirstName = Name!,
                FirstLastName = LastName!,
                ContactTypeId = (int)ContactType.Person,
                IsMainContact = true,
                IsMale = IsMale!.Value,
                CURP = RFC,
                Email = Email!,
                SecondLastName = SecondLastName,
                Birthdate = BirthDate is null ? null : DateTime.ParseExact(BirthDate, dateFormat, null),
            };

            contact.DisplayName = contact.FullName;

            return contact;
        }
    }
}
