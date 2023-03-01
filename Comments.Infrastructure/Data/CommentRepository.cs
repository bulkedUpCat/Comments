using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Comments.Application.Common.Interfaces;
using Comments.Application.Models.Comment;
using Comments.Domain.Entities;
using Comments.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Comments.Infrastructure.Data
{
    public class CommentRepository: ICommentRepository
    {
        private readonly ICommentsDbContext _context;
        
        public CommentRepository(ICommentsDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Comment>> GetAllAsync(
            CommentFilterModel model,
            CancellationToken cancellationToken)
        {
            return await _context.Comments
                .Where(c => c.ParentComment == null)
                .Sort(model.Sort, model.SortOrder)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Comment>> GetAllByParentIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Comments
                .Where(c => c.ParentComment.Id == id)
                .ToListAsync(cancellationToken);
        }

        public async Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Comments
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
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