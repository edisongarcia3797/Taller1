using FluentValidation;
using Taller1.Domain.Models;

namespace Taller1.Domain.Validations
{
    public class IntegerValidator : AbstractValidator<Integer>
    {
        public IntegerValidator()
        {
            RuleFor(x => x.Num1).NotNull().GreaterThan(0);
            RuleFor(x => x.Num2).NotNull().GreaterThan(0);
        }
    }

    public class ComplexValidator : AbstractValidator<Complex>
    {
        public ComplexValidator()
        {
            RuleFor(x => x.Num1).NotNull();
            RuleFor(x => x.Num2).NotNull();
            RuleFor(x => x.Imaginary1).NotNull();
            RuleFor(x => x.Imaginary2).NotNull();
        }
    }
}
