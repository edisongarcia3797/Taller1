using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Taller1.Domain.Models;
using Taller1.Infrastructure.Data.Context;
using Taller1.Infrastructure.Data.Repositories;

namespace Taller1.Tests
{
    [TestClass]
    public class OperationRepositoryTests
    {
        [TestMethod]
        public async Task SaveOperationAsyncTest()
        {
            var mockSet = new Mock<DbSet<Operation>>();
            var mockContext = new Mock<IOperationContext>();
            mockContext.Setup(m => m.Operations).Returns(mockSet.Object);

            var operation = new Operation()
            {
                IdOperation = "TestId123",
                Description = "TestDescription",
                CreationDate = DateTime.Now
            };
            var operationRepository = new OperationRepository(mockContext.Object);
            var result = await operationRepository.SaveOperationAsync(operation);

            Assert.AreEqual(operation.IdOperation, result.IdOperation);
        }

        [TestMethod]
        public void QueryOperationsTest()
        {
            DateTime StartDate = DateTime.Now.AddDays(-1);
            DateTime EndDate = DateTime.Now.AddDays(1);
            var operation = new List<Operation>
            {
                new Operation { IdOperation = "AAA", Description = "TestDescription", CreationDate = DateTime.Now},
                new Operation { IdOperation = "BBB", Description = "TestDescription", CreationDate = DateTime.Now},
                new Operation { IdOperation = "ZZZ", Description = "TestDescription", CreationDate = DateTime.Now}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Operation>>();
            mockSet.As<IQueryable<Operation>>().Setup(m => m.Provider).Returns(operation.Provider);
            mockSet.As<IQueryable<Operation>>().Setup(m => m.Expression).Returns(operation.Expression);
            mockSet.As<IQueryable<Operation>>().Setup(m => m.ElementType).Returns(operation.ElementType);
            mockSet.As<IQueryable<Operation>>().Setup(m => m.GetEnumerator()).Returns(operation.GetEnumerator());

            var mockContext = new Mock<IOperationContext>();
            mockContext.Setup(c => c.Operations).Returns(mockSet.Object);

            var operationRepository = new OperationRepository(mockContext.Object);
            var operations = operationRepository.QueryOperations(StartDate, EndDate);

            Assert.AreEqual(3, operations.Count);
            Assert.AreEqual("AAA", operations[0].IdOperation);
            Assert.AreEqual("BBB", operations[1].IdOperation);
            Assert.AreEqual("ZZZ", operations[2].IdOperation);
        }
    }
}
