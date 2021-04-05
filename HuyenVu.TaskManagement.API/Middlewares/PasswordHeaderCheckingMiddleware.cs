using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HuyenVu.TaskManagement.API.Middlewares
{
    public class PasswordHeaderCheckingMiddleware
    {
        private readonly RequestDelegate _next;

        public PasswordHeaderCheckingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine(httpContext.Request.Headers["password123"]);
            // if (httpContext.Request.Headers["password123"] == "password123456789")
                await _next(httpContext);
            // else
                // httpContext.Response.StatusCode = 403;
        }
    }

    // public static class MiddleWareExtensions
    // {
    //     public static IApplicationBuilder
    // }
}