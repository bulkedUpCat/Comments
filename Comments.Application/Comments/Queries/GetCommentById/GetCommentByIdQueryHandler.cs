using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Comments.Application.Common.Interfaces;
using Comments.Application.Models.Comment;
using MediatR;

namespace Comments.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQueryHandler: IRequestHandler<GetCommentByIdQuery, CommentModel>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(
            ICommentRepository commentRepository, 
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentModel> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<CommentModel>(comment);
        }
    }
}