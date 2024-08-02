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

        }
    }
}
