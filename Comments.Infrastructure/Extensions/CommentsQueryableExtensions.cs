using System.Linq;
using Comments.Domain.Entities;

namespace Comments.Infrastructure.Extensions
{
    public static class CommentsQueryableExtensions
    {
        public static IQueryable<Comment> Sort(
            this IQueryable<Comment> comments,
            string option,
            string sortOrder)
        {
            if (sortOrder == "ASC")
            {
                return option switch
                    {
                        "Date" => comments.OrderBy(c => c.CreatedAt),
                        "User Name" => comments.OrderBy(c => c.User.UserName),
                        "Email" => comments.OrderBy(c => c.User.Email),
                        _ => comments.OrderBy(c => c.CreatedAt)
                    };
            }

            return option switch
            {
                "Date" => comments.OrderByDescending(c => c.CreatedAt),
                "User Name" => comments.OrderByDescending(c => c.User.UserName),
                "Email" => comments.OrderByDescending(c => c.User.Email),
                _ => comments.OrderByDescending(c => c.CreatedAt)
            };
        }
    }
}