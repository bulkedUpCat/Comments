using System.Threading;
using System.Threading.Tasks;
using Comments.Application.Common.Interfaces;
using Comments.Application.Exceptions;
using MediatR;

namespace Comments.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler: IRequestHandler<UpdateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ICommentsDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdateCommentCommandHandler(
            ICommentRepository commentRepository, 
            ICommentsDbContext context,
            ICurrentUserService currentUserService)
        {
            _commentRepository = commentRepository;
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetCurrentUserId();
            
            var comment = await _commentRepository.GetByIdAsync(request.Id, cancellationToken)
                          ?? throw new CommentNotFoundException(request.Id);
            
            if (comment.UserId != userId)
            {
                throw new CommentActionNotAllowedException("You can not edit someone else's comment");
            }

            comment.Text = request.Text;

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}