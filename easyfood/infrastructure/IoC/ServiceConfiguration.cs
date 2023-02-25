using Easyfood.Application.Services.Interfaces;
using Easyfood.Infrastructure.ExternalServices;
using Easyfood.Shared.Common.User;
using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Infrastructure.IoC
{
    public static class ServiceConfiguration
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRouteApi, RouteApi>();
            services.AddScoped<UserService>();
        }
    }
}