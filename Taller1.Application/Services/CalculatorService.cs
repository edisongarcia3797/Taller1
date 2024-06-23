using Taller1.Domain.Models;

namespace Taller1.Application.Services
{
    public class CalculatorService 
    {
        public ResponseSum Sum(RequestSum requestSum)
        {
            ResponseSum responseSum = new();

            if (requestSum == null)
                throw new ArgumentNullException("El 'Producto' es requerido");

            responseSum.Result = requestSum.Num1 + requestSum.Num2;

            return responseSum;
        }
    }
}
