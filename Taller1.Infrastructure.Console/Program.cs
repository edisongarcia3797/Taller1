using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Taller1.Application.Services;
using Taller1.Domain.Models;
using Taller1.Infrastructure.Data.Context;
using Taller1.Infrastructure.Data.Repositories;

namespace Taller1.Infrastructure.Console
{
    static class Program
    {
        static  async Task Main(string[] args)
        {
            #region ConfigurationBuilder
            var serviceCollection = new ServiceCollection();
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                          .AddEnvironmentVariables();
            IConfiguration config = builder.Build();
            serviceCollection.AddSingleton<IConfiguration>(config);
            #endregion

            #region Crear servicios de aplicación
            CalculatorService CreateCalculatorService()
            {
                CalculatorService calculatorService = new CalculatorService();
                return calculatorService;
            }

            OperationService CreateOperationService()
            {
                IOperationContext db = new OperationContext(config["MYSQL_CONNECTION_STRING"] ?? "server=127.0.0.1;port=3306;database=dbTaller1;user=root;password=12345");
                db.Database.EnsureCreated();
                OperationRepository calculatorRepository = new OperationRepository(db);
                OperationService operationService = new OperationService(calculatorRepository);
                return operationService;
            }
            #endregion

            #region Invoca servicios de operación suma y guardado de la operación en la base de datos
            int num1, num2;
            string response;
            System.Console.WriteLine("Ingrese un número y presione la tecla Enter");
            num1 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Ingrese el segundo número y presione la tecla Enter");
            num2 = Convert.ToInt32(System.Console.ReadLine());

            var calculatorService = CreateCalculatorService();
            var responseSum = calculatorService.GetSum(new Sum() { Num1 = num1, Num2 = num2 });
            response = !string.IsNullOrEmpty(responseSum.ErrorMessage) ? responseSum.ErrorMessage :  $"El resultado de la operación suma es: {num1} + {num2} = " + responseSum.Result;
            System.Console.WriteLine(response);

            var operation = new Operation()
            {
                IdOperation = Guid.NewGuid().ToString(),
                Description = response,
                CreationDate = DateTime.Now
            };

            var operationService = CreateOperationService();
            await operationService.SaveOperationAsync(operation);
            #endregion

            #region Opción para consultar el histórico de operaciones
            System.Console.WriteLine("Si desea consultar el histórico de operaciones, por favor presione la tecla S");

            if (System.Console.ReadLine().ToUpperInvariant() ==  "S")
            {
                System.Console.WriteLine("Ingrese la fecha inicial del histórico de operacinoes en formato 'yyyy-MM-ddTHH:mm:ss'.");
                DateTime.TryParse(System.Console.ReadLine(), out DateTime StartDate);
                System.Console.WriteLine("Ingrese la fecha final del histórico de operacinoes en formato 'yyyy-MM-ddTHH:mm:ss'.");
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