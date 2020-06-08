using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace users_demo.Middleware
{
    // A custom middleware to add a request duration response header
    // Starts a timer (ideally first in the request pipeline),
    // and adds the elapsed time in ms to a response header.
    public class RequestTimerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = new Stopwatch();

            //Start running a timer for the request
            watch.Start();

            //Register a Response.OnStarting delegate
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.Add("X-Response-Time-Milliseconds", watch.ElapsedMilliseconds.ToString());

                return Task.CompletedTask;
            }, context);

            await _next(context);
        }
    }
}
