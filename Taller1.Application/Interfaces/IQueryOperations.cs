using Taller1.Domain.Models;

namespace Taller1.Application.Repositories
{
    public interface IQueryOperations
    {
        List<Operation> QueryOperations(DateTime StartDate, DateTime EndDate);
    }
}
