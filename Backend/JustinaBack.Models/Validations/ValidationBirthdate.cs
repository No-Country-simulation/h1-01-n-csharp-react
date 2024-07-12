using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace JustinaBack.Models
{
    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public DateRangeAttribute()
        {
            _minDate = DateTime.Today.AddYears(-100);
            _maxDate = DateTime.Today;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            DateTime parseDate;

            var canParse = DateTime.TryParseExact((string)value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parseDate);

            if (canParse)
            {

                if (parseDate is DateTime date)
                {
                    if (date < _minDate || date > _maxDate)
                    {
                        return new ValidationResult($"The Birthdate must be between 100 years ago and today");
                    }
                }

                return ValidationResult.Success!;
            }
            return new ValidationResult($"The Birthdate must be a valid Date");
        }
    }
}
