using Easyfood.Shared.Common.Response;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Easyfood.Shared.Common.ExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string errors = "";
            string path = $"{context.Request.PathBase}{context.Request.Path}{context.Request.QueryString}";
            string traceId = "VAZIO";

            switch (exception)
            {
                case ValidationException v:
                    statusCode = HttpStatusCode.BadRequest;
                    errors = string.Join(',', v.Errors?.Select(x => x?.ErrorMessage) ?? Enumerable.Empty<string>());
                    _logger.LogWarning($"[BAD REQUEST]: {errors} - [PATH]: {path} - [TRACE]: {traceId}");
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    errors = exception.Message;
                    _logger.LogError($"[ERROR]: {errors} - [PATH]: {path} - [TRACE]: {traceId} -  [EXCEPTION]: {exception}");
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var error = new ErrorResponse(statusCode.ToString(), errors, errors, path, traceId);

            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}