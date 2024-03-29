﻿using Easyfood.Shared.Common.ExceptionMiddleware;
using Microsoft.AspNetCore.Builder;

namespace Easyfood.Infrastructure.IoC
{
    public static class ExceptionMiddlewareConfiguration
    {
        public static void AddCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}