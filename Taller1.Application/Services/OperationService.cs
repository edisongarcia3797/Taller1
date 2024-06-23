using Taller1.Application.Interfaces;
using Taller1.Domain.Interfaces.Repositories;
using Taller1.Domain.Models;

namespace Taller1.Application.Services
{
    public class OperationService : IOperationService
    {
        private readonly IRepository _repository;

        public OperationService(IRepository repository)
        {
            _repository = repository;
        }

        public List<Operation> QueryOperations(DateTime StartDate, DateTime EndDate)
        {
            return _repository.QueryOperations(StartDate, EndDate);
        }

        public async Task<Operation> SaveOperationAsync(Operation operation)
        {
            return await _repository.SaveOperationAsync(operation);
        }
    }
}
