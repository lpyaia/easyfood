using Easyfood.Partners.Application.Abstractions.Persistence;
using Easyfood.Partners.Domain.Abstractions;
using Easyfood.Partners.Domain.Entities;
using Easyfood.Partners.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Easyfood.Partners.Infrastructure.Persistence.EF
{
    public class PartnersDbContext : DbContext, IPartnersDbContext
    {
        public DbSet<Merchant> Merchants => Set<Merchant>();

        public DbSet<Address> Address => SetInternal<Address>();

        public DbSet<Review> Reviews => SetInternal<Review>();

        public DbSet<Menu> Menus => SetInternal<Menu>();

        public DbSet<MenuItem> MenuItems => SetInternal<MenuItem>();

        public DbSet<Owner> Owners => SetInternal<Owner>();

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class, IAggregateRoot
            => base.Set<TEntity>();

        private DbSet<TEntity> SetInternal<TEntity>() where TEntity : class
            => base.Set<TEntity>();

        public PartnersDbContext(DbContextOptions<PartnersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PartnersDbContext).Assembly);
        }
    }
}