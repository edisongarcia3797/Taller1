using Taller1.Domain.Models;

namespace Taller1.Application.Repositories
{
    public interface IRepository 
    {
        List<Operation> QueryOperations(DateTime StartDate, DateTime EndDate);
        Task<Operation> SaveOperationAsync(Operation operation);
    }
}
