using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Taller1.Application.Services;
using Taller1.Domain.Models;
using Taller1.Infrastructure.Data.Context;
using Taller1.Infrastructure.Data.Repositories;

namespace Taller1.Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {
        [TestMethod]
        public void GetSumOkTest()
        {
            var sum = new Sum()
            {
                Num1 = 20,
                Num2 = 24
            };

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSum(sum);

            Assert.AreEqual(response.Result, 44);
            Assert.AreEqual(response.ErrorMessage, null);
        }

        [TestMethod]
        public void GetSumNum1NegativeTest()
        {
            var sum = new Sum()
            {
                Num1 = -20,
                Num2 = 24
            };

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSum(sum);

            Assert.IsTrue(!string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNull(response.Result);
        }

        [TestMethod]
        public void GetSumNum2NegativeTest()
        {
            var sum = new Sum()
            {
                Num1 = 20,
                Num2 = -24
            };

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSum(sum);

            Assert.IsTrue(!string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNull(response.Result);
        }

        [TestMethod]
        public void GetSumNum1NullTest()
        {
            var sum = new Sum()
            {
                Num1 = null,
                Num2 = 24
            };

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSum(sum);

            Assert.IsTrue(!string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNull(response.Result);
        }

        [TestMethod]
        public void GetSumNum2NullTest()
        {
            var sum = new Sum()
            {
                Num1 = 20,
                Num2 = null
            };

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSum(sum);

            Assert.IsTrue(!string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNull(response.Result);
        }
    }
}
