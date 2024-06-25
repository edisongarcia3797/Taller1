using Taller1.Application.Repositories;
using Taller1.Domain.Models;

namespace Taller1.Application.Services
{
    public class OperationService 
    {
        private readonly IRepository _repository;

        public OperationService(IRepository repository)
        {
            _repository = repository;
        }

        public List<Operation> QueryOperations(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                return _repository.QueryOperations(StartDate, EndDate);
            }
            catch (Exception ex) 
            {
                throw new Exception($"An error occurred during the query operation", ex);
            }
        }

        public async Task<Operation> SaveOperationAsync(Operation operation)
        {
            try
            {
                return await _repository.SaveOperationAsync(operation);
            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred during the save operation", ex);
            }
        }
    }
}
