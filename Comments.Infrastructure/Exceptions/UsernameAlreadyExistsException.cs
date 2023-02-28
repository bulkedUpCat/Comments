using System;

namespace Comments.Infrastructure.Exceptions
{
    public class UsernameAlreadyExistsException: Exception
    {
        public UsernameAlreadyExistsException(string userName): base($"User with user name {userName} already exists"){}
    }
}