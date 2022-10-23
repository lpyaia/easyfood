using Easyfood.Partners.Application.Models.Merchants;
using Easyfood.Partners.Application.Services.Interfaces;
using Easyfood.Partners.Domain.ValueObjects;
using Microsoft.Extensions.Caching.Memory;

namespace Easyfood.Partners.Infrastructure.ExternalServices
{
    public class RouteApi : IRouteApi
    {
        private readonly IMemoryCache _memoryCache;

        public RouteApi(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<DeliveryDto> GetDistance(Guid userId, Location from, Location to)
        {
            if (!_memoryCache.TryGetValue(userId, out DeliveryDto value))
            {
                // calling external service
                // ...
                value = new DeliveryDto(4.5m, 56);
                _memoryCache.Set(userId, value, DateTimeOffset.Now.AddDays(1));
            }

            return value;
        }
    }
}