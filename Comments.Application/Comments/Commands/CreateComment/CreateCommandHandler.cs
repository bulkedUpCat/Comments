using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Comments.Application.Common.Interfaces;
using Comments.Application.Models.Comment;
using Comments.Domain.Entities;
using MediatR;

namespace Comments.Application.Comments.Commands.CreateComment
{
    public class CreateCommandHandler: IRequestHandler<CreateCommentCommand, CommentModel>
    {
        private readonly ICommentsDbContext _context;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CreateCommandHandler(
            ICommentsDbContext context, 
            ICommentRepository commentRepository,
            IMapper mapper)
        {
            _context = context;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentModel> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request);

            await _commentRepository.CreateAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CommentModel>(comment);
        }
    }
}