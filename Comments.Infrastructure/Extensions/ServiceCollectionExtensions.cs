using Comments.Application.Common.Interfaces;
using Comments.Infrastructure.Auth.Interfaces;
using Comments.Infrastructure.Auth.Services;
using Comments.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Comments.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<ICommentsDbContext, CommentsDbContext>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }

        public static IServiceCollection ConfigureAuthServices(
            this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtHandler, JwtHandler>();

            return services;
        }
    }
}