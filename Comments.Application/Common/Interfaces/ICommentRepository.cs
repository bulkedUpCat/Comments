using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Comments.Application.Models.Comment;
using Comments.Domain.Entities;

namespace Comments.Application.Common.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync(CommentFilterModel model, CancellationToken cancellationToken);
        Task<IEnumerable<Comment>> GetAllByParentIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Comment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(Comment comment, CancellationToken cancellationToken);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}