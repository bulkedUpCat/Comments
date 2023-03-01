using Comments.Application.Exceptions;

namespace Comments.Infrastructure.Exceptions
{
    public class EmailAlreadyExistsException: BadRequestException
    {
        public EmailAlreadyExistsException(string email): base($"User with email {email} already exists"){}
    }
}