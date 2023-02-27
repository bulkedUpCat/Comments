using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Comments.Application.Common.Interfaces;
using Comments.Application.Models.Comment;
using MediatR;

namespace Comments.Application.Comments.Queries.GetAllComments
{
    public class GetAllCommentsQueryHandler: IRequestHandler<GetAllCommentsQuery, IEnumerable<CommentModel>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetAllCommentsQueryHandler(
            ICommentRepository commentRepository, 
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentModel>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<CommentModel>>(comments);
        }
    }
}