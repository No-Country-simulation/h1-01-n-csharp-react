using DTOs.MedRecord;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class MedRecordAddValidator : AbstractValidator<MedRecordAddDto>
    {
        public MedRecordAddValidator()
        {
            RuleFor(x => x.Weight)
                .NotEmpty().WithMessage("Weight es requerido.")
                .InclusiveBetween(2.0, 635.0).WithMessage("Weight debe estar entre 2 y 635 kg.");

            RuleFor(x => x.Height)
                .NotEmpty().WithMessage("Height es requerido.")
                .InclusiveBetween(30.0, 272.0).WithMessage("Height debe estar entre 30 y 272 cm.");

            RuleFor(x => x.IsAlcoholic)
                .NotNull().WithMessage("IsAlcoholic es requerido.");

            RuleFor(x => x.IsSmoker)
                .NotNull().WithMessage("IsSmoker es requerido.");

            RuleFor(x => x.UsesDrugs)
                .NotNull().WithMessage("UsesDrugs es requerido.");
        }
    }
}
