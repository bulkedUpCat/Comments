using Comments.Application.Models.Comment;
using Comments.Application.Models.Shared;
using MediatR;

namespace Comments.Application.Comments.Queries.GetAllComments
{
    public class GetAllCommentsQuery: IRequest<PagedList<CommentModel>>
    {
        public string? Sort { get; set; }
        public string? SortOrder { get; set; }
        public int Page { get; set; } = 1;
        public int PageCount { get; set; } = 25;
    }
}