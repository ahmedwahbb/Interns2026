using Microsoft.EntityFrameworkCore;
using NorthWaveConsole.Domain.Entities;

namespace NorthWaveConsole.Infrastructure.Persistence
{
    public class NorthWaveDbContext : DbContext
    {
        public NorthWaveDbContext(DbContextOptions<NorthWaveDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthWaveDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
