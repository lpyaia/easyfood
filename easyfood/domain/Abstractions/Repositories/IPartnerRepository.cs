using Easyfood.Domain.Entities;

namespace Easyfood.Domain.Abstractions.Repositories
{
    public interface IPartnerRepository
    {
        Task<IEnumerable<Partner>> GetActiveParnersPaginatedAsync(int page, int pageSize);

        Task<int> GetActiveParnersCountAsync();
    }
}