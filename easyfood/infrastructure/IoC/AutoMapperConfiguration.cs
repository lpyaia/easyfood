using Easyfood.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Infrastructure.IoC
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(ApplicationAssembly.Assembly);
        }
    }
}