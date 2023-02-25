using Easyfood.Shared.Authorization.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Infrastructure.IoC
{
    public static class AuthorizationRequirimentConfiguration
    {
        public static void AddAuthorizationRequirement(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, SeasonedWorkerRequirementHandler>();
        }
    }
}