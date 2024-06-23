using Taller1.Domain.Models;

namespace Taller1.Domain.Interfaces
{
    public interface ISaveOperation
    {
        Task<Operation> SaveOperationAsync(Operation operation);
    }
}
