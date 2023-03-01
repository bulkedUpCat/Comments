using Comments.Application.Exceptions;

namespace Comments.Infrastructure.Exceptions
{
    public class UsernameAlreadyExistsException: BadRequestException
    {
        public UsernameAlreadyExistsException(string userName): base($"User with user name {userName} already exists"){}
    }
}