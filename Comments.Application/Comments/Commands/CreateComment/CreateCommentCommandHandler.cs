using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Comments.Application.Common.Interfaces;
using Comments.Application.Exceptions;
using Comments.Application.Models.Comment;
using Comments.Domain.Entities;
using MediatR;

namespace Comments.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler: IRequestHandler<CreateCommentCommand, CommentModel>
    {
        private readonly ICommentsDbContext _context;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(
            ICommentsDbContext context, 
            ICommentRepository commentRepository,
            IUserRepository userRepository,
            ICurrentUserService currentUserService,
            IMapper mapper)
        {
            _context = context;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<CommentModel> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetCurrentUserId();

            var user = await _userRepository.GetByIdAsync(userId, cancellationToken)
                       ?? throw new UserNotFoundException(userId);
            
            var comment = _mapper.Map<Comment>(request);

            comment.User = user;

            if (request.ParentCommentId != null)
            {
                var parentComment = await _commentRepository
                                        .GetByIdAsync(request.ParentCommentId.Value, cancellationToken)
                                    ?? throw new CommentNotFoundException(request.ParentCommentId.Value);

                comment.ParentComment = parentComment;
            }

            await _commentRepository.CreateAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CommentModel>(comment);
        }
    }
}