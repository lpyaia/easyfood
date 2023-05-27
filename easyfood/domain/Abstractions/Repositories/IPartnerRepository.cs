using Easyfood.Domain.Entities.Partners;
using Easyfood.Domain.Enums;

namespace Easyfood.Domain.Abstractions.Repositories
{
    public interface IPartnerRepository : IRepository<Partner>
    {
        Task<IEnumerable<Partner>> GetActiveParnersPaginatedAsync(int page,
            int pageSize,
            string? search,
            CompanyType[]? companyTypes,
            Guid[]? tagsId,
            CancellationToken cancellationToken);

        Task<int> GetActiveParnersCountAsync(string? search,
            CompanyType[]? companyTypes,
            Guid[]? tagsId,
            CancellationToken cancellationToken);
    }
}