using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using APIDashboard.Entities.Models;
using APIDashboard.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace APIDashboard.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, DBAPIDASHBOARDContext db)
        {

            
            if (!httpContext.Request.Headers.Keys.Contains("API-KEY-USER"))
            {
                if (!httpContext.Request.Path.Value.Contains("/api/"))
                {
                    httpContext.Response.StatusCode = 200;
                    await _next.Invoke(httpContext);
                }
                else {
                    httpContext.Response.StatusCode = 400; //Bad Request                
                    await httpContext.Response.WriteAsync("User Key is missing");
                    return;
                }
                
            }
            else
            {
                var getKey = httpContext.Request.Headers["API-KEY-USER"];
                if (!db.TdUser.Where(w => w.ApiKey == getKey.ToString()).Any())
                {
                    httpContext.Response.StatusCode = 401; //UnAuthorized
                    await httpContext.Response.WriteAsync("Invalid User Key");
                    return;


                }
            }


            await _next.Invoke(httpContext);
            
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiKeyMiddleware>();
            
            return app;
        }
    }
}
