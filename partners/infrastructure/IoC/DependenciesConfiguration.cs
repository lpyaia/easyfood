using Easyfood.Partners.Application.Services.Interfaces;
using Easyfood.Partners.Infrastructure.ExternalServices;
using Easyfood.Shared.Common.User;
using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Partners.Infrastructure.IoC
{
    public static class DependenciesConfiguration
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRouteApi, RouteApi>();
            services.AddScoped<UserService>();
        }
    }
}