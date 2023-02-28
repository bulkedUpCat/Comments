using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Comments.Domain.Entities;

namespace Comments.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task CreateAsync(User user, CancellationToken cancellationToken);
        void Update(User user);
        void Delete(User user);
    }
}