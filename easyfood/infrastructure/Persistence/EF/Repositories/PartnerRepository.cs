using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Domain.Entities;

namespace Easyfood.Infrastructure.Persistence.EF.Repositories
{
    public class PartnerRepository : Repository<Partner>, IPartnerRepository
    {
        public PartnerRepository(EasyfoodDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetActiveParnersCountAsync()
        {
            return await CountAsync(x => x.IsActive);
        }

        public async Task<IEnumerable<Partner>> GetActiveParnersPaginatedAsync(int page, int pageSize)
        {
            return await SelectPaginatedAsync(x => x.IsActive, page, pageSize);
        }
    }
}