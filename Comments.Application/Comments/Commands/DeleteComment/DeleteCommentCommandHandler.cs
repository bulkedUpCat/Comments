using System.Threading;
using System.Threading.Tasks;
using Comments.Application.Common.Interfaces;
using Comments.Application.Exceptions;
using MediatR;

namespace Comments.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler: IRequestHandler<DeleteCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentsDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteCommentCommandHandler(
            ICommentRepository commentRepository, 
            ICommentsDbContext context, 
            ICurrentUserService currentUserService)
        {
            _commentRepository = commentRepository;
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetCurrentUserId();
            
            var comment = await _commentRepository.GetByIdAsync(request.Id, cancellationToken)
                          ?? throw new CommentNotFoundException(request.Id);

            if (comment.UserId != userId)
            {
                throw new CommentActionNotAllowedException("You can not delete someone else's comment");
            }

            _commentRepository.Delete(comment);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}