using System;

namespace Comments.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid GetCurrentUserId();
    }
}