using FluentValidation;
using Taller1.Domain.Models;

namespace Taller1.Domain.Validations
{
    public class IntegerSumValidator : AbstractValidator<Integer>
    {
        public IntegerSumValidator()
        {
            RuleFor(x => x.Num1).NotNull().GreaterThanOrEqualTo(-10);
            RuleFor(x => x.Num2).NotNull().GreaterThanOrEqualTo(-10);
        }
    }

    public class ComplexSumValidator : AbstractValidator<Complex>
    {
        public ComplexSumValidator()
        {
            RuleFor(x => x.Num1).NotNull();
            RuleFor(x => x.Num2).NotNull();
            RuleFor(x => x.Imaginary1).NotNull();
            RuleFor(x => x.Imaginary2).NotNull();
        }
    }
}
