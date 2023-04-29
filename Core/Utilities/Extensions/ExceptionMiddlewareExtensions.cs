using Core.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Core.Utilities.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}