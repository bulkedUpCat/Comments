using System;
using Comments.Application.Models.Comment;
using MediatR;

namespace Comments.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQuery: IRequest<CommentModel>
    {
        public Guid Id { get; set; }
    }
}