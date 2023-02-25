using Easyfood.Domain.Abstractions;
using Easyfood.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Easyfood.Infrastructure.Persistence.EF.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected readonly EasyfoodDbContext _dbContext;

        public Repository(EasyfoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<T>()
                                   .CountAsync();
        }

        protected async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>()
                                   .Where(expression)
                                   .CountAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>()
                      .Remove(entity);
        }

        protected async Task<T?> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>()
                                   .FirstOrDefaultAsync(expression);
        }

        public async Task InsertAsync(T entity)
        {
            await _dbContext.Set<T>()
                            .AddAsync(entity);
        }

        protected async Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>()
                                   .Where(expression)
                                   .ToListAsync();
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dbContext.Set<T>()
                                   .ToListAsync();
        }

        protected async Task<IEnumerable<T>> SelectPaginatedAsync(Expression<Func<T, bool>> expression, int page, int pageSize)
        {
            return await _dbContext.Set<T>()
                                   .Where(expression)
                                   .Skip(page * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
        }

        public async Task<IEnumerable<T>> SelectPaginatedAsync(int page, int pageSize)
        {
            return await _dbContext.Set<T>()
                                   .Skip(page * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
        }

        public async Task<T?> FindById(Guid id)
        {
            return await _dbContext.Set<T>()
                                   .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}