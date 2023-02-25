using System.Linq.Expressions;

namespace Easyfood.Domain.Abstractions.Repositories
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task InsertAsync(T entity);

        void Delete(T entity);

        Task<int> CountAsync();

        Task<T?> FindById(Guid id);

        Task<IEnumerable<T>> SelectAsync();

        Task<IEnumerable<T>> SelectPaginatedAsync(int page, int pageSize);
    }
}