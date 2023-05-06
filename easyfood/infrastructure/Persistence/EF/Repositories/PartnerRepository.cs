using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities.Partners;

namespace Easyfood.Infrastructure.Persistence.EF.Repositories
{
    public class PartnerRepository : Repository<Partner>, IPartnerRepository
    {
        public PartnerRepository(EasyfoodDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetActiveParnersCountAsync(CancellationToken cancellationToken)
        {
            return await CountAsync(x => x.IsActive, cancellationToken);
        }

        public async Task<IEnumerable<Partner>> GetActiveParnersPaginatedAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            return await GetPaginatedAsync(page, pageSize, x => x.IsActive, cancellationToken);
        }
    }
}