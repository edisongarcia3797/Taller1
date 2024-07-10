using Taller1.Domain.Interfaces;
using Taller1.Domain.Models;

namespace Taller1.Domain
{
    public class MultiplicationInteger : IMultiplication
    {
        private readonly Integer _integer;

        public MultiplicationInteger(Integer integer)
        {
            _integer = integer;
        }

        public string? GetMultiplicationTwoNumbers()
        {
            return Convert.ToString(_integer.Num1 * _integer.Num2);
        }

        public string? GetMultiplicationNumbers()
        {
            int? mult = 1;

            if (_integer.Numbers != null && _integer.Numbers.Any())
            {
                foreach (int num in _integer.Numbers)
                {
                    mult *= num;
                }
            }

            return Convert.ToString(mult);
        }
    }
}
