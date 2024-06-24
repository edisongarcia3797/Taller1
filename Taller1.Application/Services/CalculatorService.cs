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
            try
            {
                ValidationResult result = _sumValidator.Validate(requestSum);
                if (!result.IsValid)
                {
                    foreach (var error in result.Errors)
                        responseSum.ErrorMessage = $"A business validation error occurred. Error detail: {error.PropertyName} {error.ErrorMessage}";
                    return responseSum;
                }

                responseSum.Result = requestSum.Num1 + requestSum.Num2;
            }
            catch (Exception ex) 
            { 
                responseSum.ErrorMessage = $"An error occurred during the sum operation. Error detail: {ex.Message}";
            }

            return responseSum;
        }
    }
}
