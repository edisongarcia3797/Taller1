using Microsoft.EntityFrameworkCore;
using Taller1.Domain.Models;

namespace Taller1.Infrastructure.Data.Context
{
    public abstract class IOperationContext : DbContext
    {
        public IOperationContext()  
        {

        }

        public IOperationContext(DbContextOptions<IOperationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Operation> Operations { get; set; }
    }
}
