using Microsoft.EntityFrameworkCore;

namespace Easyfood.Infrastructure.Persistence.EF
{
    public class EasyfoodDbContext : DbContext
    {
        public EasyfoodDbContext(DbContextOptions<EasyfoodDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EasyfoodDbContext).Assembly);
        }
    }
}