using DTOs.Medicine;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class MedDosageAddValidator : AbstractValidator<MedDosageAddDto>
    {
        public MedDosageAddValidator()
        {
            RuleFor(x => x.CurrentDosage)
                .NotEmpty().WithMessage("CurrentDosage es requerido.")
                .Matches(@"^\d+[a-zA-Z]+$").WithMessage("CurrentDosage debe tener un formato de números seguidos de letras, como '50mg'.");

            RuleFor(x => x.Instructions)
                .NotEmpty().WithMessage("Instructions es requerido.");

            RuleFor(x => x.MedicineId)
                .GreaterThan(0).WithMessage("MedicineId debe ser superior a 0.");
        }
    }
}
