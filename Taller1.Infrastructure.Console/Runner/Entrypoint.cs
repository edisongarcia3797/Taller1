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

            #region Invoca servicios para sumar dos números enteros y guardado de la operación en la base de datos
            int num1, num2, imaginary1, imaginary2;
            string response;
            System.Console.WriteLine("(Suma 2 Números Enteros) -> Ingrese un número y presione la tecla Enter");
            num1 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("(Suma 2 Números Enteros) -> Ingrese el segundo número y presione la tecla Enter");
            num2 = Convert.ToInt32(System.Console.ReadLine());

            var calculatorService = CreateCalculatorService();

            ISum sumTwoInteger = new SumInteger(new Integer() { Num1 = num1,Num2 = num2});
            var responseSumTwoNumbers = calculatorService.GetSumTwoNumbers(sumTwoInteger);

            response = !string.IsNullOrEmpty(responseSumTwoNumbers.ErrorMessage) ? responseSumTwoNumbers.ErrorMessage : $"El resultado de la operación suma es: {num1} + {num2} = " + responseSumTwoNumbers.Result;
            System.Console.WriteLine(response);

            var operationService = CreateOperationService();
            await operationService.SaveOperationAsync(new Operation()
            {
                IdOperation = Guid.NewGuid().ToString(),
                Description = response,
                CreationDate = DateTime.Now
            });
            #endregion

            #region Invoca servicios para sumar dos números complejos y guardado de la operación en la base de datos

            System.Console.WriteLine("(Suma 2 Números Complejos) -> Ingrese un número real y presione la tecla Enter");
            num1 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("(Suma 2 Números Complejos) -> Ingrese el segundo número real y presione la tecla Enter");
            num2 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("(Suma 2 Números Complejos) -> Ingrese un número que represente la parte imaginaria y presione la tecla Enter");
            imaginary1 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("(Suma 2 Números Complejos) -> Ingrese el segundo número que represente la parte imaginaria  y presione la tecla Enter");
            imaginary2 = Convert.ToInt32(System.Console.ReadLine());

            ISum sumComplex = new SumComplex(new Complex() { Num1 = num1, Imaginary1 = imaginary1, Num2 = num2, Imaginary2 = imaginary2 });
            responseSumTwoNumbers = calculatorService.GetSumTwoNumbers(sumComplex);

            response = !string.IsNullOrEmpty(responseSumTwoNumbers.ErrorMessage) ? responseSumTwoNumbers.ErrorMessage : $"El resultado de la operación suma es: ({num1} + {imaginary1}i) + ({num2} + {imaginary2}i)= " + responseSumTwoNumbers.Result;
            System.Console.WriteLine(response);

            await operationService.SaveOperationAsync(new Operation()
            {
                IdOperation = Guid.NewGuid().ToString(),
                Description = response,
                CreationDate = DateTime.Now
            });
            #endregion

            #region Invoca servicios para sumar varios números enteros y guardado de la operación en la base de datos
            int[] numbers;

            System.Console.WriteLine("(Suma Números Enteros) -> Ingrese varios números separados por coma ',' y presione la tecla Enter");
            numbers = System.Console.ReadLine().Split(',')
                             .Select(int.Parse)
                             .ToArray(); ;

            ISum sumInteger = new SumInteger(new Integer() { Numbers = numbers});
            var responseSumNumbers = calculatorService.GetSumNumbers(sumInteger);

            response = !string.IsNullOrEmpty(responseSumNumbers.ErrorMessage) ? responseSumNumbers.ErrorMessage : $"El resultado de sumar '{string.Join("+", (from a in numbers select a.ToString()).ToList())}' es: " + responseSumNumbers.Result;
            System.Console.WriteLine(response);

            await operationService.SaveOperationAsync(new Operation()
            {
                IdOperation = Guid.NewGuid().ToString(),
                Description = response,
                CreationDate = DateTime.Now
            });
            #endregion

            #region Invoca servicios para multiplicar dos números enteros y guardado de la operación en la base de datos

            System.Console.WriteLine("(Multiplicación 2 Números Enteros) -> Ingrese un número y presione la tecla Enter");
            num1 = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("(Multiplicación 2 Números Enteros) -> Ingrese el segundo número y presione la tecla Enter");
            num2 = Convert.ToInt32(System.Console.ReadLine());

            IMultiplication multTwoInteger = new MultiplicationInteger(new Integer() { Num1 = num1, Num2 = num2 });
            var responseMultiplicationTwoNumbers = calculatorService.GetMultiplicationTwoNumbers(multTwoInteger);

            response = !string.IsNullOrEmpty(responseMultiplicationTwoNumbers.ErrorMessage) ? responseMultiplicationTwoNumbers.ErrorMessage : $"El resultado de multiplicar: {num1} * {num2} = " + responseMultiplicationTwoNumbers.Result;
            System.Console.WriteLine(response);

            await operationService.SaveOperationAsync(new Operation()
            {
                IdOperation = Guid.NewGuid().ToString(),
                Description = response,
                CreationDate = DateTime.Now
            });
            #endregion

            #region Invoca servicios para multiplicar varios números enteros y guardado de la operación en la base de datos
            
            System.Console.WriteLine("(Multiplicación Números Enteros) -> Ingrese varios números separados por coma ',' y presione la tecla Enter");
            numbers = System.Console.ReadLine().Split(',')
                             .Select(int.Parse)
                             .ToArray(); ;

            IMultiplication multInteger = new MultiplicationInteger(new Integer() { Numbers = numbers });
            var responseMultiplicationNumbers = calculatorService.GetMultiplicationNumbers(multInteger);

            response = !string.IsNullOrEmpty(responseMultiplicationNumbers.ErrorMessage) ? responseMultiplicationNumbers.ErrorMessage : $"El resultado de multiplicar '{string.Join("*", (from a in numbers select a.ToString()).ToList())}' es: " + responseMultiplicationNumbers.Result;
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
