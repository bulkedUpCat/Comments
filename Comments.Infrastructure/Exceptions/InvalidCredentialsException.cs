using System;

namespace Comments.Infrastructure.Exceptions
{
    public class InvalidCredentialsException: Exception
    {
        public InvalidCredentialsException(): base("Invalid email or password"){}
    }
}