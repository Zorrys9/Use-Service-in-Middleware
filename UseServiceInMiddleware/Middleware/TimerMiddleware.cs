using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseServiceInMiddleware.Services;
using Microsoft.Extensions.DependencyInjection;
namespace UseServiceInMiddleware.Middleware
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate _next;
        public TimerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, TimerService timerService)
        {
            if(context.Request.Path.Value.ToLower() == "/time")
            {
                context.Response.ContentType = "text/html;charset=utf-8";
                //TimerService timer = context.RequestServices.GetService<TimerService>();
                await context.Response.WriteAsync($"Текущее время: {timerService?.Time}");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
