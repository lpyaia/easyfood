using Easyfood.Application.Models.Partners;
using Easyfood.Application.Services.Interfaces;
using Easyfood.Domain.ValueObjects;
using Microsoft.Extensions.Caching.Memory;

namespace Easyfood.Infrastructure.ExternalServices
{
    public class RouteApi : IRouteApi
    {
        private readonly IMemoryCache _memoryCache;

        public RouteApi(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<DeliveryDto> GetDistance(Guid userId, Guid partnerId, Location from, Location to)
        {
            var key = new { userId, partnerId };
            var rnd = new Random(DateTime.Now.Millisecond);

            if (!_memoryCache.TryGetValue(key, out DeliveryDto value))
            {
                // calling external service
                // ...
                value = new DeliveryDto(
                    (decimal)(rnd.NextDouble() * 20),
                    rnd.Next(10, 60),
                    (decimal)(rnd.NextDouble() * 6));

                _memoryCache.Set(key, value, DateTimeOffset.Now.AddDays(1));
            }

            return value;
        }
    }
}