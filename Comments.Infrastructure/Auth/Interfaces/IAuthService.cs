using System.Threading;
using System.Threading.Tasks;
using Comments.Application.Models.User;
using Comments.Infrastructure.Auth.Models;

namespace Comments.Infrastructure.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<JwtTokenModel> LoginAsync(LoginModel model, CancellationToken cancellationToken);
        Task<UserModel> SignupAsync(SignupModel model, CancellationToken cancellationToken);
    }
}