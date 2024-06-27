using Microsoft.Extensions.Configuration;
using System.Text;
using Taller1.Application.Services;
using Taller1.Domain;
using Taller1.Domain.Interfaces;
using Taller1.Domain.Models;
using Taller1.Infrastructure.Data.Context;
using Taller1.Infrastructure.Data.Repositories;

namespace Taller1.Infrastructure.Console.Runner
{
    public class Entrypoint 
    {
        private readonly IConfiguration _configuration;
        public Entrypoint(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Execute()
        {
            #region Crear servicios de aplicación
            CalculatorService CreateCalculatorService()
            {
                CalculatorService calculatorService = new CalculatorService();
                return calculatorService;
            }

            OperationService CreateOperationService()
            {
                IOperationContext db = new OperationContext(_configuration["MYSQL_CONNECTION_STRING"] ?? _configuration["DataBaseSettings:MySql"]);
                db.Database.EnsureCreated();
                OperationRepository calculatorRepository = new OperationRepository(db);
                OperationService operationService = new OperationService(calculatorRepository);
                return operationService;
            }
            #endregion

            #region Invoca servicios de operación suma de números enteros y guardado de la operación en la base de datos
            int num1, num2, imaginary1, imaginary2;
            string response;
            System.Console.WriteLine("Ingrese un número y presione la tecla Enter");
            num1 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Ingrese el segundo número y presione la tecla Enter");
            num2 = Convert.ToInt32(System.Console.ReadLine());

            var calculatorService = CreateCalculatorService();

            ISum sumInteger = new SumInteger(new Integer() { Num1 = num1,Num2 = num2});
            var responseSum = calculatorService.GetSum(sumInteger);

            response = !string.IsNullOrEmpty(responseSum.ErrorMessage) ? responseSum.ErrorMessage : $"El resultado de la operación suma es: {num1} + {num2} = " + responseSum.Result;
            System.Console.WriteLine(response);

            var operationService = CreateOperationService();
            await operationService.SaveOperationAsync(new Operation()
            {
                IdOperation = Guid.NewGuid().ToString(),
                Description = response,
                CreationDate = DateTime.Now
            });
            #endregion

            #region Invoca servicios de operación suma de números complejos y guardado de la operación en la base de datos

            System.Console.WriteLine("Ingrese un número real y presione la tecla Enter");
            num1 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Ingrese el segundo número real y presione la tecla Enter");
            num2 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Ingrese un número que represente la parte imaginaria y presione la tecla Enter");
            imaginary1 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Ingrese el segundo número que represente la parte imaginaria  y presione la tecla Enter");
            imaginary2 = Convert.ToInt32(System.Console.ReadLine());

            ISum sumComplex = new SumComplex(new Complex() { Num1 = num1, Imaginary1 = imaginary1, Num2 = num2, Imaginary2 = imaginary2 });
            responseSum = calculatorService.GetSum(sumComplex);

            response = !string.IsNullOrEmpty(responseSum.ErrorMessage) ? responseSum.ErrorMessage : $"El resultado de la operación suma es: ({num1} + {imaginary1}i) + ({num2} + {imaginary2}i)= " + responseSum.Result;
            System.Console.WriteLine(response);

            await operationService.SaveOperationAsync(new Operation()
            {
                IdOperation = Guid.NewGuid().ToString(),
                Description = response,
                CreationDate = DateTime.Now
            });
            #endregion

            #region Opción para consultar el histórico de operaciones
            System.Console.WriteLine("Si desea consultar el histórico de operaciones, por favor presione la tecla S");

            if (System.Console.ReadLine().ToUpperInvariant() == "S")
            {
                System.Console.WriteLine("Ingrese la fecha inicial del histórico de operacinoes en formato 'yyyy-MM-ddTHH:mm:ss'. Ejemplo: (2024-06-23T20:00:00)");
                DateTime.TryParse(System.Console.ReadLine(), out DateTime StartDate);
                System.Console.WriteLine("Ingrese la fecha final del histórico de operacinoes en formato 'yyyy-MM-ddTHH:mm:ss'. Ejemplo: (2024-06-23T20:00:00)");
                DateTime.TryParse(System.Console.ReadLine(), out DateTime EndDate);

                var listOperation = operationService.QueryOperations(StartDate, EndDate);
                foreach (var item in listOperation)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"IdOperation: {item.IdOperation}");
                    data.AppendLine($"Description: {item.Description}");
                    data.AppendLine($"CreationDate: {item.CreationDate}");
                    System.Console.WriteLine(data.ToString());
                }
            }
            #endregion

            System.Console.Write("Presinoes cualquier tecla para salir de la consola.");
            System.Console.ReadKey();
        }
    }
}
