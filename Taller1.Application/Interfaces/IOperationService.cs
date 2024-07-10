using Taller1.Domain.Models;

namespace Taller1.Application.Interfaces
{
    public interface IOperationService
    {
        List<Operation> QueryOperations(DateTime StartDate, DateTime EndDate);
        Task<Operation> SaveOperationAsync(Operation operation);
    }
}
