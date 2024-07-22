using DTOs.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class PatientAddValidator : AbstractValidator<RegisterPatientRequest>
    {
        public PatientAddValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName es requerido.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName es requerido.");

            RuleFor(x => x.DNI)
                .NotEmpty().WithMessage("DNI es requerido.")
                .Length(8).WithMessage("DNI debe tener exactamente 8 dígitos.")
                .Matches(@"^\d+$").WithMessage("DNI debe contener solo dígitos.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("BirthDate es requerida.")
                .LessThan(DateTime.Now).WithMessage("BirthDate debe ser una fecha en el pasado.")
                .Must(BeAValidAge).WithMessage("La fecha de nacimiento no es válida.");

            RuleFor(x => x.IsManagedByParent)
                .NotNull().WithMessage("IsManagedByParent es requerido.");

            RuleFor(x => x.ParentName)
                .NotEmpty().WithMessage("ParentName es requerido si IsManagedByParent es true.")
                .When(x => x.IsManagedByParent); 

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address es requerido.");

            RuleFor(x => x.BloodType)
                .IsInEnum().WithMessage("BloodType debe ser uno de los valores permitidos.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email es requerido.")
                .EmailAddress().WithMessage("Email debe ser una dirección de correo válida.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password es requerido.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$")
                .WithMessage("La contraseña debe tener al menos 6 caracteres, incluyendo al menos una letra mayúscula, un número y un carácter especial.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("ConfirmPassword es requerido.")
                .Equal(x => x.Password).WithMessage("Las contraseñas no coinciden.");
        }

        private bool BeAValidAge(DateTime birthDate)
        {
            var minDateOfBirth = DateTime.Now.AddYears(-120); 
            var maxDateOfBirth = DateTime.Now.AddDays(-1);

            return birthDate <= maxDateOfBirth && birthDate >= minDateOfBirth;
        }
    }
}
