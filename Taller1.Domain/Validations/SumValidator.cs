using FluentValidation;
using Taller1.Domain.Models;

namespace Taller1.Domain.Validations
{
    public class SumValidator : AbstractValidator<Sum>
    {
        public SumValidator() 
        {
            RuleFor(x => x.Num1).NotNull().GreaterThan(0);
            RuleFor(x => x.Num2).NotNull().GreaterThan(0);
        }
    }
}
