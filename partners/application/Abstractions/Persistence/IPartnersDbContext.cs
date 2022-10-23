using Easyfood.Partners.Domain.Abstractions;
using Easyfood.Partners.Domain.Entities;
using Easyfood.Partners.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Easyfood.Partners.Application.Abstractions.Persistence
{
    public interface IPartnersDbContext
    {
        DbSet<Merchant> Merchants { get; }

        //DbSet<Address> Address { get; }

        //DbSet<Review> Reviews { get; }

        //DbSet<Menu> Menus { get; }

        //DbSet<MenuItem> MenuItems { get; }

        //DbSet<Owner> Owners { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class, IAggregateRoot;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}