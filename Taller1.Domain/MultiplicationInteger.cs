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
    }
}
