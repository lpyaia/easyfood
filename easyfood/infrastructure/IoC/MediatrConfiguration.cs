using Easyfood.Application;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Infrastructure.IoC
{
    public static class MediatrConfiguration
    {
        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(ApplicationAssembly.Assembly);
        }
    }
}