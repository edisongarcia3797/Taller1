using Microsoft.EntityFrameworkCore;
using Taller1.Domain.Models;

namespace Taller1.Infrastructure.Data.Context
{
    public class OperationContext : IOperationContext
    {
        private readonly string _connectionString;
        public OperationContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
        public override DbSet<Operation> Operations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasKey(e => e.IdOperation);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.CreationDate).IsRequired();
            });
        }
    }
}
