using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Comments.Application.Common.Interfaces;
using Comments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comments.Infrastructure.Data
{
    public class CommentRepository: ICommentRepository
    {
        private readonly CommentsDbContext _context;
        
        public CommentRepository(CommentsDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Comment>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Comments.ToListAsync(cancellationToken);
        }

        public async Task CreateAsync(Comment comment, CancellationToken cancellationToken)
        {
            await _context.Comments.AddAsync(comment, cancellationToken);
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
        }

        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
        }
    }
}