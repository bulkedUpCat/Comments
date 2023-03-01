using System;
using System.Threading.Tasks;
using Comments.Application.Exceptions;
using Comments.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Comments.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = StatusCodes.Status500InternalServerError;

            switch (exception)
            {
                case InvalidCredentialsException:
                    code = StatusCodes.Status401Unauthorized;
                    break;
                case BadRequestException:
                    code = StatusCodes.Status400BadRequest;
                    break;
                case NotFoundException:
                    code = StatusCodes.Status404NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new {error = exception.Message}));
        }
    }
}