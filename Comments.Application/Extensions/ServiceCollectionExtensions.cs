using Comments.Application.Comments.Queries.GetAllComments;
using Microsoft.Extensions.DependencyInjection;

namespace Comments.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureMediator(
            this IServiceCollection services)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(GetAllCommentsQuery).Assembly);
            });
            
            return services;
        }
    }
}