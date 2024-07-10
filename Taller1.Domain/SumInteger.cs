using Taller1.Domain.Interfaces;
using Taller1.Domain.Models;
using Taller1.Domain.Validations;

namespace Taller1.Domain
{
    public class SumInteger : ISum
    {
        private readonly IntegerSumValidator _integerValidator;
        private readonly Integer _integer;

        public SumInteger(Integer integer)
        {
            _integerValidator = new IntegerSumValidator();
            _integer = integer;
        }

        public string? GetSumTwoNumbers()
        {
            var result = _integerValidator.Validate(_integer);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                    return $"A business validation error occurred. Error detail: {error.PropertyName} {error.ErrorMessage}";
            }

            return Convert.ToString(_integer.Num1 + _integer.Num2);
        }

        public string? GetSumNumbers()
        {
            int? sum = 0;

            if (_integer.Numbers != null && _integer.Numbers.Any())
            {
                foreach (int num in _integer.Numbers)
                {
                    sum += num;
                }
            }

            return Convert.ToString(sum);
        }
    }
}
