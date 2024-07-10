using Microsoft.AspNetCore.Mvc;
using Taller1.Application.Interfaces;
using Taller1.Domain.Interfaces;
using Taller1.Domain;
using Taller1.Domain.Models;

namespace Taller1.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IOperationService _operationService;
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService, IOperationService operationService, ILogger<CalculatorController> logger)
        {
            _logger = logger;
            _operationService = operationService;
            _calculatorService = calculatorService;
        }

        [HttpPost(Name = "SumTwoNumbersInteger")]
        public async Task<IActionResult> SumTwoNumbersInteger([FromBody] Models.RequestTwoNumbersInteger requestData)
        {
            if (ModelState.IsValid)
            {
                Models.ResponseData responseData;
                try
                {
                    ISum sumTwoInteger = new SumInteger(new Integer() { Num1 = requestData.Num1, Num2 = requestData.Num2 });
                    var responseSumTwoNumbers = _calculatorService.GetSumTwoNumbers(sumTwoInteger);
                   
                    responseData = new Models.ResponseData
                    {
                        Message = !string.IsNullOrEmpty(responseSumTwoNumbers.ErrorMessage) ? responseSumTwoNumbers.ErrorMessage : $"El resultado de la operación suma es: {requestData.Num1} + {requestData.Num2} = " + responseSumTwoNumbers.Result
                    };

                    await _operationService.SaveOperationAsync(new Operation()
                    {
                        IdOperation = Guid.NewGuid().ToString(),
                        Description = responseData.Message,
                        CreationDate = DateTime.Now
                    });

                    return Ok(responseData);
                }
                catch (Exception ex)
                {
                    _logger.LogError("[SumTwoNumbers] {ex.Message}", ex.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            else return BadRequest(ModelState);
        }

        [HttpPost(Name = "SumTwoNumbersComplex")]
        public async Task<IActionResult> SumTwoNumbersComplex([FromBody] Models.RequestTwoNumbersComplex requestData)
        {
            if (ModelState.IsValid)
            {
                Models.ResponseData responseData;
                try
                {
                    ISum sumTwoComplex = new SumComplex(new Complex() { Num1 = requestData.Num1, Num2 = requestData.Num2,Imaginary1 = requestData.Imaginary1, Imaginary2 = requestData.Imaginary2 });
                    var responseSumTwoNumbers = _calculatorService.GetSumTwoNumbers(sumTwoComplex);

                    responseData = new Models.ResponseData
                    {
                        Message = !string.IsNullOrEmpty(responseSumTwoNumbers.ErrorMessage) ? responseSumTwoNumbers.ErrorMessage : $"El resultado de la operación suma es: ({requestData.Num1} + {requestData.Imaginary1}i) + ({requestData.Num2} + {requestData.Imaginary2}i)= " + responseSumTwoNumbers.Result
                    };

                    await _operationService.SaveOperationAsync(new Operation()
                    {
                        IdOperation = Guid.NewGuid().ToString(),
                        Description = responseData.Message,
                        CreationDate = DateTime.Now
                    });

                    return Ok(responseData);
                }
                catch (Exception ex)
                {
                    _logger.LogError("[SumTwoNumbers] {ex.Message}", ex.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            else return BadRequest(ModelState);
        }
    }
}
