using Easyfood.Partners.Domain.Entities;
using Easyfood.Partners.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Easyfood.Partners.Infrastructure.Persistence.EF
{
    public class PartnersDbContext : DbContext
    {
        public DbSet<Merchant> Merchants { get; set; } = default!;

        public DbSet<Address> Address { get; set; } = default!;

        public DbSet<Review> Reviews { get; set; } = default!;

        public DbSet<Menu> Menus { get; set; } = default!;

        public DbSet<MenuItem> MenuItems { get; set; } = default!;

        public DbSet<Owner> Owners { get; set; } = default!;

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