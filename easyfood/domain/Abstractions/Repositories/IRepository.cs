using System.Linq.Expressions;

namespace Easyfood.Domain.Abstractions.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        Task<TEntity?> GetByIdAsync(Guid id,
            CancellationToken cancellationToken,
            params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetListByIdAsync(List<Guid> Ids,
            CancellationToken cancellationToken,
            params Expression<Func<TEntity, object>>[] includes);

        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> GetPaginatedAsync(int page, int pageSize, CancellationToken cancellationToken);

        void Insert(params TEntity[] entities);

        void Update(params TEntity[] entities);

        void InsertOrUpdate(params TEntity[] entities);

        void Remove(Guid id);

        Task<int> CountAsync(CancellationToken cancellationToken);
    }
}