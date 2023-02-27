using System.Collections.Generic;
using Comments.Application.Models.Comment;
using MediatR;

namespace Comments.Application.Comments.Queries.GetAllComments
{
    public class GetAllCommentsQuery: IRequest<IEnumerable<CommentModel>>
    {
        
    }
}