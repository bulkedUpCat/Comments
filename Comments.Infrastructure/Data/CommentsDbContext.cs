using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Comments.Application.Common.Interfaces;
using Comments.Domain.Entities;
using Comments.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Comments.Infrastructure.Data
{
    public class CommentsDbContext: DbContext, ICommentsDbContext
    {
        public CommentsDbContext(DbContextOptions<CommentsDbContext> options): base(options){}

        public DbSet<Comment> Comments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(CommentConfiguration).Assembly);
        }
        
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditEntityProperties();
            return await base.SaveChangesAsync(cancellationToken);
        }
        
        private void AddAuditEntityProperties()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditEntity<Guid> &&
                            (e.State == EntityState.Added ||
                             e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var auditEntity = (AuditEntity<Guid>)entityEntry.Entity;
                auditEntity.ModifiedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    auditEntity.CreatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}