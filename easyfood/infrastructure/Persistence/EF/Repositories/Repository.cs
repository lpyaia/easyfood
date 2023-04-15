using Easyfood.Domain.Abstractions;
using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Easyfood.Infrastructure.Persistence.EF.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        protected readonly EasyfoodDbContext _dbContext;

        public Repository(EasyfoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id,
            CancellationToken cancellationToken,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include.ConvertExpressionToEfIncludeString());
            }

            return await query.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetListByIdAsync(List<Guid> Ids,
            CancellationToken cancellationToken,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>()
                                  .Where(x => Ids.Contains(x.Id));

            foreach (var include in includes)
            {
                query = query.Include(include.ConvertExpressionToEfIncludeString());
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public void Insert(params TEntity[] entities)
        {
            foreach (var entity in entities)
                _dbContext.Add(entity);
        }

        public void Update(params TEntity[] entities)
        {
            foreach (var entity in entities)
                _dbContext.Update(entity);
        }

        public virtual void InsertOrUpdate(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                if (_dbContext.Entry(entity).State == EntityState.Added ||
                    _dbContext.Entry(entity).State == EntityState.Detached)
                    _dbContext.Add(entity);
                else if (_dbContext.Entry(entity).State == EntityState.Modified)
                    _dbContext.Update(entity);
            }
        }

        public virtual void Remove(Guid id)
        {
            var entity = _dbContext.Set<TEntity>()
                                   .Find(id);

            if (entity != null)
            {
                entity.DeletedAt = DateTime.UtcNow;
            }
        }

        public async Task<IEnumerable<TEntity>> GetPaginatedAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>()
                                   .OrderByDescending(x => x.CreatedAt)
                                   .Skip(page * pageSize)
                                   .Take(pageSize)
                                   .AsNoTracking()
                                   .ToListAsync(cancellationToken);
        }

        protected async Task<IEnumerable<TEntity>> GetPaginatedAsync(int page,
            int pageSize,
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>()
                                   .Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.OrderByDescending(x => x.CreatedAt)
                              .Skip(page * pageSize)
                              .Take(pageSize)
                              .AsNoTracking()
                              .ToListAsync(cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>().CountAsync(cancellationToken);
        }

        protected async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>()
                                   .Where(predicate)
                                   .CountAsync(cancellationToken);
        }
    }
}