using Taller1.Domain.Interfaces;
using Taller1.Domain.Models;

namespace Taller1.Application.Services
{
    public class CalculatorService
    {
        public Response GetSum(ISum sum)
        {
            Response response = new();
            try
            {
                response.Result = sum.GetResult();
            }
            catch (Exception ex) 
            {
                response.ErrorMessage = $"An error occurred during the sum operation. Error detail: {ex.Message}";
            }

            return response;
        }
    }
}
