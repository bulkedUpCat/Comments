using System;

namespace Comments.Application.Exceptions
{
    public class UserNotFoundException: NotFoundException
    {
        public UserNotFoundException(Guid id): base($"User with id {id} was not found"){}
    }
}