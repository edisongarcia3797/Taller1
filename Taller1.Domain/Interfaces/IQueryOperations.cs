using Taller1.Domain.Models;

namespace Taller1.Domain.Interfaces
{
    public interface IQueryOperations
    {
        List<Operation> QueryOperations(DateTime StartDate, DateTime EndDate);
    }
}
