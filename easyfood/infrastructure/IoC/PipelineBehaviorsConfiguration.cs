using Easyfood.Shared.Common.PipelineBehaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Easyfood.Infrastructure.IoC
{
    public static class PipelineBehaviorsConfiguration
    {
        public static void AddPipelineBehaviors(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AppLoggingBehavior<,>));
        }
    }
}