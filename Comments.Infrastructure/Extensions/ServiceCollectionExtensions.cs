using Comments.Application.Common.Interfaces;
using Comments.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Comments.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<ICommentRepository, CommentRepository>();
            return services;
        }
    }
}