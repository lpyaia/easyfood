using Easyfood.Application.Abstractions.Persistence;
using Easyfood.Infrastructure.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Infrastructure.IoC
{
    public static class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<IEasyfoodDbContext, EasyfoodDbContext>(options =>
                    options.UseInMemoryDatabase("PartnersDb"));
            }
            else
            {
                services.AddDbContext<IEasyfoodDbContext, EasyfoodDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("Default")!,
                        builder => builder.MigrationsAssembly(typeof(EasyfoodDbContext).Assembly.FullName)
                    ));
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}