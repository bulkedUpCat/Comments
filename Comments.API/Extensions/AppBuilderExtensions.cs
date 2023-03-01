using Comments.API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Comments.API.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}