using System;
using Microsoft.AspNetCore.Builder;

namespace users_demo.Middleware
{
    public static class RequestTimerMiddlewareExtensions
    {
        public static IApplicationBuilder UseResponseTimer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimerMiddleware>();
        }
    }
}
    