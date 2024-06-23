using Taller1.Domain.Interfaces.Repositories;
using Taller1.Domain.Models;
using Taller1.Infrastructure.Data.Context;

namespace Taller1.Infrastructure.Data.Repositories
{
    public class OperationRepository : IRepository
    {
        private readonly IOperationContext _dbContext;
 
        public OperationRepository(IOperationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Operation> SaveOperationAsync(Operation operation)
        {
            await _dbContext.Operations.AddAsync(operation);
            await _dbContext.SaveChangesAsync();
            return operation;
        }

        public List<Operation> QueryOperations(DateTime StartDate, DateTime EndDate)
        {
            return _dbContext.Operations.Where(x => x.CreationDate >= StartDate && x.CreationDate <= EndDate).ToList();
        }
    }
}
