using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities.Partners;
using Easyfood.Domain.Enums;
using Easyfood.Infrastructure.Extensions;

namespace Easyfood.Infrastructure.Persistence.EF.Repositories
{
    public class PartnerRepository : Repository<Partner>, IPartnerRepository
    {
        public PartnerRepository(EasyfoodDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetActiveParnersCountAsync(string? search,
            CompanyType[]? companyTypes,
            Guid[]? tagsId,
            CancellationToken cancellationToken)
        {
            return await CountAsync(x => x.IsActive &&
                                        (!search.HasValue() || x.CompanyName.Contains(search!)) &&
                                        (
                                            tagsId != null && tagsId.Length > 0 && x.Tags.Any(x => tagsId.Contains(x.Id)) ||
                                            (
                                                (tagsId == null || tagsId.Length == 0) &&
                                                (companyTypes == null || companyTypes!.Length == 0 || companyTypes.Contains(x.CompanyCategory))
                                            )
                                        ),
                                    cancellationToken);
        }

        public async Task<IEnumerable<Partner>> GetActiveParnersPaginatedAsync(int page,
            int pageSize,
            string? search,
            CompanyType[]? companyTypes,
            Guid[]? tagsId,
            CancellationToken cancellationToken)
        {
            return await GetPaginatedAsync(page,
                pageSize,
                x => x.IsActive &&
                    (!search.HasValue() || x.CompanyName.Contains(search!)) &&
                    (
                        tagsId != null && tagsId.Length > 0 && x.Tags.Any(x => tagsId.Contains(x.Id)) ||
                        (
                            (tagsId == null || tagsId.Length == 0) &&
                            (companyTypes == null || companyTypes!.Length == 0 || companyTypes.Contains(x.CompanyCategory))
                        )
                    ),
                cancellationToken);
        }
    }
}