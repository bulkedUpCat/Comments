using System;
using System.Linq;
using System.Security.Claims;
using Comments.Application.Common.Interfaces;
using Comments.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Comments.Infrastructure.Auth.Services
{
    public class CurrentUserService: ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        
        public Guid GetCurrentUserId()
        {
            var value = _contextAccessor?.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (value == null)
            {
                throw new InvalidCredentialsException();
            }

            var userId = Guid.Parse(value);

            return userId;
        }
    }
}