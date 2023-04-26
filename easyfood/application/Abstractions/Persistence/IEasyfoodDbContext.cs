using Microsoft.EntityFrameworkCore;

namespace Easyfood.Application.Abstractions.Persistence
{
    public interface IEasyfoodDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}