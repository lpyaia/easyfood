using Easyfood.Partners.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Partners.Infrastructure.IoC
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(ApplicationAssembly.Assembly);
        }
    }
}