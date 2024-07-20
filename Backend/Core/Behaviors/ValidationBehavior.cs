using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Behaviors
{
    public class ValidationBehavior<T> : IValidationBehavior<T>
    {
        private readonly IValidator<T> _validator;

        public ValidationBehavior(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async Task ValidateFields(T model)
        {
            var validator = await _validator.ValidateAsync(model);

            if (!validator.IsValid)
            {
                var errors = validator.Errors.ToList();

                throw new ValidationException(errors);
            }
        }
    }
}
