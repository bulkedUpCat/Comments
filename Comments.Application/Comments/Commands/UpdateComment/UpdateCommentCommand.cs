using System;
using MediatR;

namespace Comments.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand: IRequest
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}