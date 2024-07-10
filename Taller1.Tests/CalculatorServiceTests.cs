using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taller1.Application.Services;
using Taller1.Domain.Interfaces;
using Taller1.Domain;
using Taller1.Domain.Models;

namespace Taller1.Tests
{
    [TestClass]
    public class CalculatorServiceTests
    {
        [TestMethod]
        public void GetSumOkTest()
        {
            ISum sumInteger = new SumInteger(new Integer() { Num1 = 20, Num2 = 24 });

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSumTwoNumbers(sumInteger);

            Assert.AreEqual(response.Result, Convert.ToString(44));
        }

        [TestMethod]
        public void GetSumNum1NegativeTest()
        {
            ISum sumInteger = new SumInteger(new Integer() { Num1 = -20, Num2 = 24 });

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSumTwoNumbers(sumInteger);

            Assert.AreEqual(response.Result, "A business validation error occurred. Error detail: Num1 'Num1' debe ser mayor o igual que '-10'.");
        }

        [TestMethod]
        public void GetSumNum2NegativeTest()
        {
            ISum sumInteger = new SumInteger(new Integer() { Num1 = 20, Num2 = -24 });

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSumTwoNumbers(sumInteger);

            Assert.AreEqual(response.Result, "A business validation error occurred. Error detail: Num2 'Num2' debe ser mayor o igual que '-10'.");
        }

        [TestMethod]
        public void GetSumNum1NullTest()
        {
            ISum sumInteger = new SumInteger(new Integer() { Num1 = null, Num2 = 24 });

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSumTwoNumbers(sumInteger);

            Assert.AreEqual(response.Result, "A business validation error occurred. Error detail: Num1 'Num1' no debe estar vacío.");
        }

        [TestMethod]
        public void GetSumNum2NullTest()
        {
            ISum sumInteger = new SumInteger(new Integer() { Num1 = 20, Num2 = null });

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSumTwoNumbers(sumInteger);

            Assert.AreEqual(response.Result, "A business validation error occurred. Error detail: Num2 'Num2' no debe estar vacío.");
        }

        [TestMethod]
        public void GetSumComplexOkTest()
        {
            ISum sumComplex = new SumComplex(new Complex() { Num1 = 1, Imaginary1 = 5, Num2 = 3, Imaginary2 = 2 });

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSumTwoNumbers(sumComplex);

            Assert.AreEqual(response.Result, "4 + 7i");
        }

        [TestMethod]
        public void GetSumNum1ComplexNullTest()
        {
            ISum sumComplex = new SumComplex(new Complex() { Num1 = null, Imaginary1 = 5, Num2 = 3, Imaginary2 = 2 });

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSumTwoNumbers(sumComplex);

            Assert.AreEqual(response.Result, "A business validation error occurred. Error detail: Num1 'Num1' no debe estar vacío.");
        }

        [TestMethod]
        public void GetSumNum2ComplexNullTest()
        {
            ISum sumComplex = new SumComplex(new Complex() { Num1 = 1, Imaginary1 = 5, Num2 = null, Imaginary2 = 2 });

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSumTwoNumbers(sumComplex);

            Assert.AreEqual(response.Result, "A business validation error occurred. Error detail: Num2 'Num2' no debe estar vacío.");
        }

        [TestMethod]
        public void GetSumImaginary1ComplexNullTest()
        {
            ISum sumComplex = new SumComplex(new Complex() { Num1 = 1, Imaginary1 = null, Num2 = 8, Imaginary2 = 2 });

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSumTwoNumbers(sumComplex);

            Assert.AreEqual(response.Result, "A business validation error occurred. Error detail: Imaginary1 'Imaginary1' no debe estar vacío.");
        }

        [TestMethod]
        public void GetSumImaginary2ComplexNullTest()
        {
            ISum sumComplex = new SumComplex(new Complex() { Num1 = 1, Imaginary1 = 5, Num2 = 8, Imaginary2 = null });

            var calculatorService = new CalculatorService();
            var response = calculatorService.GetSumTwoNumbers(sumComplex);

            Assert.AreEqual(response.Result, "A business validation error occurred. Error detail: Imaginary2 'Imaginary2' no debe estar vacío.");
        }
    }
}
