using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Easyfood.Api.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class SubscriptionKeyAuthorizationAttribute : Attribute, IAsyncActionFilter
    {
        private const string SUBSCRIPTION_KEY_HEADER = "subscription-key";

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(SUBSCRIPTION_KEY_HEADER, out var requestSubscriptionKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Subscription key não encontrada"
                };

                return;
            }

            var config = context.HttpContext.RequestServices.GetService<IConfiguration>()!;
            string apiKey = config.GetValue<string>("ApiKey")!;

            if (!apiKey.Equals(requestSubscriptionKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Acesso não autorizado"
                };

                return;
            }

            await next();
        }
    }
}