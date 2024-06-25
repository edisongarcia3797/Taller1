using Taller1.Domain.Models;

namespace Taller1.Application.Repositories
{
    public interface ISaveOperation
    {
        Task<Operation> SaveOperationAsync(Operation operation);
    }
}
