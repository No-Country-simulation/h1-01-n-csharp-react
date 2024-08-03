using DTOs.ClinicalHistory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class ClinicalHistoryAddValidator : AbstractValidator<ClinicalHistoryAddDto>
    {
        public ClinicalHistoryAddValidator()
        {
            RuleFor(x => x.MedicName)
                .NotEmpty().WithMessage("MedicName es requerido.");

            RuleFor(x => x.DiagnosisDate)
                .NotEmpty().WithMessage("DiagnosisDate es requerido.")
                .Must(BeAValidAge).WithMessage("La fecha de diagnóstico no es válida.");

            RuleFor(x => x.PathologyId)
                .NotEmpty().WithMessage("PathologyId es requerido.")
                .NotEqual(0).WithMessage("PathologyId no puede ser 0.");
        }

        private bool BeAValidAge(DateTime date)
        {
            var minDate = DateTime.Now.AddYears(-120);
            var maxDate = DateTime.Now.AddDays(-1);

            return date <= maxDate && date >= minDate;
        }
    }
}
