using System;

namespace Comments.Application.Exceptions
{
    public class CommentNotFoundException: NotFoundException
    {
        public CommentNotFoundException(Guid id) : base($"Comment with id {id} was not found"){}
    }
}