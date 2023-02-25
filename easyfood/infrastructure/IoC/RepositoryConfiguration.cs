using Easyfood.Domain.Abstractions.Repositories;
using Easyfood.Infrastructure.Persistence.EF.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Infrastructure.IoC
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPartnerRepository, PartnerRepository>();
        }
    }
}