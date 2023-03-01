using System;
using Comments.Application.Models.Comment;
using MediatR;

namespace Comments.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand: IRequest<CommentModel>
    {
        public string Text { get; set; }
        public Guid? ParentCommentId { get; set; }
    }
}