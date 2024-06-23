using Taller1.Domain.Models;
using Taller1.Domain.Validations;
using FluentValidation.Results;

namespace Taller1.Application.Services
{
    public class CalculatorService
    {
        private readonly SumValidator _sumValidator;
        public CalculatorService()
        {
            _sumValidator = new SumValidator();
        }

        public Sum GetSum(Sum requestSum)
        {
            Sum responseSum = new();

            ValidationResult result = _sumValidator.Validate(requestSum);

            responseSum.Result = requestSum.Num1 + requestSum.Num2;

            if (!result.IsValid)
                foreach (var error in result.Errors)
                    Console.WriteLine($"Error en {error.PropertyName} {error.ErrorMessage}");


            return responseSum;
        }
    }
}
