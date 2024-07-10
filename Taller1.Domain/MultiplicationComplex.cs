using Taller1.Domain.Interfaces;
using Taller1.Domain.Models;

namespace Taller1.Domain
{
    public class MultiplicationComplex : IMultiplication
    {
        private readonly Complex _complex;

        public MultiplicationComplex(Complex complex)
        {
            _complex = complex;
        }

        public string GetMultiplicationTwoNumbers()
        {
            int? newReal = _complex.Num1 * _complex.Num2;
            int? newImaginary = _complex.Imaginary1 * _complex.Imaginary2;
            return $"{newReal} + {newImaginary}i";
        }
    }
}
