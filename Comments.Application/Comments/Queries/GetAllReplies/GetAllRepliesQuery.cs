using System;
using System.Collections.Generic;
using Comments.Application.Models.Comment;
using MediatR;

namespace Comments.Application.Comments.Queries.GetAllReplies
{
    public class GetAllRepliesQuery: IRequest<IEnumerable<CommentModel>>
    {
        public Guid ParentCommentId { get; set; }
    }
}