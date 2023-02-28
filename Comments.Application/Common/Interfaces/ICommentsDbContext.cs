using System.Threading;
using System.Threading.Tasks;
using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comments.Application.Common.Interfaces
{
    public interface ICommentsDbContext
    {
        DbSet<Comment> Comments { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}