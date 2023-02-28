using System.Threading;
using System.Threading.Tasks;
using Comments.Infrastructure.Auth.Interfaces;
using Comments.Infrastructure.Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comments.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginModel model,
            CancellationToken cancellationToken)
        {
            var jwtToken = await _authService.LoginAsync(model, cancellationToken);
            return Ok(jwtToken);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(
            SignupModel model,
            CancellationToken cancellationToken)
        {
            var user = await _authService.SignupAsync(model, cancellationToken);
            return Ok(user);
        }
    }
}