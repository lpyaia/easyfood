using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Easyfood.Shared.Common.PipelineBehaviors
{
    public class AppLoggingBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<AppLoggingBehavior<TRequest, TResponse>> _logger;

        public AppLoggingBehavior(ILogger<AppLoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;

            _logger.LogInformation($"[Begin] request name: {requestName}");

            var timer = new Stopwatch();
            timer.Start();
            var response = await next();
            timer.Stop();

            _logger.LogInformation($"[End] request name:{requestName}, total request time:{timer.ElapsedMilliseconds}");

            return response;
        }
    }
}