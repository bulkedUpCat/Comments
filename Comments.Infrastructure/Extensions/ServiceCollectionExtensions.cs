using Azure.Storage.Blobs;
using Comments.Application.Common.Interfaces;
using Comments.Infrastructure.Auth.Interfaces;
using Comments.Infrastructure.Auth.Services;
using Comments.Infrastructure.Data;
using Comments.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        
        public static IServiceCollection ConfigureHttpContextAccessor(
            this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }

        public static IServiceCollection ConfigureAzureBlobStorage(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(_ => new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorage")));
            services.AddScoped<IStorageService, AzureBlobStorageService>();
            
            return services;
        }
    }
}