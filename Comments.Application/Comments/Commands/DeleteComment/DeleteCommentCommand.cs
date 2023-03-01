using System;
using MediatR;

namespace Comments.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}