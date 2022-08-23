using Easyfood.Partners.Infrastructure.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// USAR ESCOPO TRANSIENT PARA TRANSAÇÕES ENTITY FRAMEWORK

namespace Easyfood.Partners.Infrastructure.IoC
{
    public static class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<PartnersDbContext>(options =>
                    options.UseInMemoryDatabase("PartnersDb"));
            }
            else
            {
                services.AddDbContext<PartnersDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("Default"),
                        builder => builder.MigrationsAssembly(typeof(PartnersDbContext).Assembly.FullName)
                    ));
            }
        }
    }
}