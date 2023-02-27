using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comments.Infrastructure.Data
{
    public class CommentsDbContext: DbContext
    {
        public CommentsDbContext(DbContextOptions<CommentsDbContext> options): base(options){}

        public DbSet<Comment> Comments { get; set; }
    }
}