using Taller1.Domain.Interfaces;
using Taller1.Domain.Models;
using Taller1.Domain.Validations;

namespace Taller1.Domain
{
    public class SumComplex : ISum
    {
        private readonly ComplexValidator _complexValidator;
        private readonly Complex _complex;

        public SumComplex(Complex complex)
        {
            _complexValidator = new ComplexValidator();
            _complex = complex;
        }

        public string GetResult()
        {
            var result = _complexValidator.Validate(_complex);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                    return  $"A business validation error occurred. Error detail: {error.PropertyName} {error.ErrorMessage}";
            }

            int? newReal = _complex.Num1 + _complex.Num2;
            int? newImaginary = _complex.Imaginary1 + _complex.Imaginary2;
            return $"{newReal} + {newImaginary}i";
        }
    }
}
