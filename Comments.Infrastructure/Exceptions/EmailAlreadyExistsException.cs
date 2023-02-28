using System;

namespace Comments.Infrastructure.Exceptions
{
    public class EmailAlreadyExistsException: Exception
    {
        public EmailAlreadyExistsException(string email): base($"User with email {email} already exists"){}
    }
}