using System;
using Comments.Application.Models.Comment;
using MediatR;

namespace Comments.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand: IRequest<CommentModel>
    {
        /*public string UserName { get; set; }
        public string Email { get; set; }
        public string HomePage { get; set; }*/
        public string Text { get; set; }
        public Guid? ParentCommentId { get; set; }
    }
}