using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Comments.Application.Common.Interfaces;
using Comments.Application.Exceptions;
using Comments.Application.Models.Comment;
using MediatR;

namespace Comments.Application.Comments.Queries.GetAllReplies
{
    public class GetAllRepliesQueryHandler: IRequestHandler<GetAllRepliesQuery, IEnumerable<CommentModel>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetAllRepliesQueryHandler(
            ICommentRepository commentRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentModel>> Handle(GetAllRepliesQuery request, CancellationToken cancellationToken)
        {
            _ = await _commentRepository.GetByIdAsync(request.ParentCommentId, cancellationToken)
                          ?? throw new CommentNotFoundException(request.ParentCommentId);

            var replies = await _commentRepository
                .GetAllByParentIdAsync(request.ParentCommentId, cancellationToken);

            return _mapper.Map<IEnumerable<CommentModel>>(replies);
        }
    }
}