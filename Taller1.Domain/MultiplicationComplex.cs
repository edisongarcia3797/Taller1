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

        public string GetMultiplicationNumbers()
        {
            int? multNumber = 1, multImaginary = 1;

            if (_complex.Numbers != null && _complex.Numbers.Any() && _complex.Imaginarys != null && _complex.Imaginarys.Any())
            {
                foreach (int num in _complex.Numbers)
                {
                    multNumber *= num;
                }

                foreach (int imaginary in _complex.Imaginarys)
                {
                    multImaginary *= imaginary;
                }
            }

            return $"{multNumber} + {multImaginary}i";
        }
    }
}
