using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Comments.Application.Common.Interfaces;
using Comments.Application.Models.Comment;
using Comments.Application.Models.Shared;
using MediatR;

namespace Comments.Application.Comments.Queries.GetAllComments
{
    public class GetAllCommentsQueryHandler: IRequestHandler<GetAllCommentsQuery, PagedList<CommentModel>>
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

        public async Task<PagedList<CommentModel>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var filterModel = _mapper.Map<CommentFilterModel>(request);
            var comments = await _commentRepository.GetAllAsync(filterModel, cancellationToken);
            var commentModels = _mapper.Map<IEnumerable<CommentModel>>(comments).ToList();
            
            var pagedList = PagedList<CommentModel>
                .ToPagedModel(commentModels, commentModels.Count, request.Page, request.PageCount);
            
            return pagedList;
        }
    }
}