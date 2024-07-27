﻿using DTOs.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class MedicAddValidator : AbstractValidator<RegisterMedicRequest>
    {
        public MedicAddValidator()
        {

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName es requerido.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName es requerido.");

            RuleFor(x => x.DNI)
                .NotEmpty().WithMessage("DNI es requerido.")
                .Length(8).WithMessage("DNI debe tener exactamente 8 dígitos.")
                .Matches(@"^\d+$").WithMessage("DNI debe contener solo dígitos.");

            RuleFor(x => x.License)
                .NotEmpty().WithMessage("License es requerido.")
                .Length(5, 8).WithMessage("License debe tener entre 5 y 8 dígitos.")
                .Matches(@"^\d+$").WithMessage("License debe contener solo dígitos.");

            RuleFor(x => x.SpecialtyId)
                .NotEmpty().WithMessage("EspecialidadId es requerido.");

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
    }
}