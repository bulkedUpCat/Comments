using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comments.Infrastructure.Data.Configurations
{
    public class CommentConfiguration: IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .Property(c => c.Text)
                .HasMaxLength(10000)
                .IsRequired();
            
            builder
                .HasMany(c => c.Replies)
                .WithOne(c => c.ParentComment);

            builder
                .HasOne(c => c.User)
                .WithMany(u => u.Comments);
        }
    }
}