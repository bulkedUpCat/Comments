using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comments.Infrastructure.Data
{
    public class CommentsContext: DbContext
    {
        public CommentsContext(DbContextOptions<CommentsContext> options): base(options){}

        public DbSet<Comment> Comments { get; set; }
    }
}