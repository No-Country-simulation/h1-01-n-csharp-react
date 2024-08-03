using DTOs.Appointment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class AppointmentAddValidator : AbstractValidator<AppointmentAddDto>
    {
        public AppointmentAddValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date es requerida.")
                .GreaterThan(DateTime.Now).WithMessage("Date debe ser una fecha en el futuro.");

            RuleFor(x => x.Hour)
                .NotEmpty().WithMessage("Hour es requerida.")
                .GreaterThan(DateTime.Now).WithMessage("Hour debe ser en el futuro.");

            RuleFor(x => x.AppointmentType)
                .IsInEnum().WithMessage("AppointmentType debe ser uno de los valores permitidos.");

        }
    }
}
