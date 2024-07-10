using Taller1.Application.Interfaces;
using Taller1.Domain.Interfaces;
using Taller1.Domain.Models;

namespace Taller1.Application.Services
{
    public class CalculatorService : ICalculatorService
    {
        public Response GetSumTwoNumbers(ISum sum)
        {
            Response response = new();
            try
            {
                response.Result = sum.GetSumTwoNumbers();
            }
            catch (Exception ex) 
            {
                response.ErrorMessage = $"An error occurred during the sum operation. Error detail: {ex.Message}";
            }

            return response;
        }

        public Response GetSumNumbers(ISum sum)
        {
            Response response = new();
            try
            {
                response.Result = sum.GetSumNumbers();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"An error occurred during the sum operation. Error detail: {ex.Message}";
            }

            return response;
        }

        public Response GetMultiplicationTwoNumbers(IMultiplication mult)
        {
            Response response = new();
            try
            {
                response.Result = mult.GetMultiplicationTwoNumbers();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"An error occurred during the sum operation. Error detail: {ex.Message}";
            }

            return response;
        }

        public Response GetMultiplicationNumbers(IMultiplication mult)
        {
            Response response = new();
            try
            {
                response.Result = mult.GetMultiplicationNumbers();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"An error occurred during the sum operation. Error detail: {ex.Message}";
            }

            return response;
        }
    }
}
