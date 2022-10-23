using Easyfood.Partners.Application;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Partners.Infrastructure.IoC
{
    public static class MediatrConfiguration
    {
        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(ApplicationAssembly.Assembly);
        }
    }
}