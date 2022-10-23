using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Partners.Infrastructure.IoC
{
    public static class CacheConfiguration
    {
        public static void AddCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}