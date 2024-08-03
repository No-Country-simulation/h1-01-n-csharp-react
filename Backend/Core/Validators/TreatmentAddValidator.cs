using DTOs.Treatment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class TreatmentAddValidator : AbstractValidator<TreatmentAddDto>
    {
        public TreatmentAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name es requerido.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("StartDate es requerida.")
                .GreaterThan(DateTime.Now).WithMessage("StartDate debe ser una fecha en el futuro.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("EndDate es requerida.")
                .GreaterThan(x => x.StartDate).WithMessage("EndDate debe ser una fecha posterior a StartDate.");

            RuleFor(x => x.PathologyId)
                .GreaterThan(0).WithMessage("PathologyId debe ser superior a 0.");

            RuleForEach(x => x.MedDosages).SetValidator(new MedDosageAddValidator());
        }
    }
}
