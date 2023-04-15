﻿using Easyfood.Domain.Entities;

namespace Easyfood.Domain.Abstractions.Repositories
{
    public interface IPartnerRepository : IRepository<Partner>
    {
        Task<IEnumerable<Partner>> GetActiveParnersPaginatedAsync(int page, int pageSize, CancellationToken cancellationToken);

        Task<int> GetActiveParnersCountAsync(CancellationToken cancellationToken);
    }
}