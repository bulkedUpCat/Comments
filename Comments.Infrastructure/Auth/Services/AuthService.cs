using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Comments.Application.Common.Interfaces;
using Comments.Application.Models.User;
using Comments.Domain.Entities;
using Comments.Infrastructure.Auth.Interfaces;
using Comments.Infrastructure.Auth.Models;
using Comments.Infrastructure.Exceptions;

namespace Comments.Infrastructure.Auth.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommentsDbContext _context;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public AuthService(
            IUserRepository userRepository, 
            ICommentsDbContext context,
            IJwtHandler jwtHandler,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _context = context;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<JwtTokenModel> LoginAsync(
            LoginModel model, 
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email, cancellationToken)
                       ?? throw new InvalidCredentialsException();

            var passwordVerified =
                VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt);

            if (!passwordVerified)
            {
                throw new InvalidCredentialsException();
            }
            
            var claims = _jwtHandler.GetClaims(user);
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var token = _jwtHandler.GenerateToken(signingCredentials, claims);
            
            return new JwtTokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            };
        }
        
        public async Task<UserModel> SignupAsync(
            SignupModel model,
            CancellationToken cancellationToken = default)
        {
            var emailExists = await _userRepository.GetByEmailAsync(model.Email, cancellationToken);

            if (emailExists != null)
            {
                throw new EmailAlreadyExistsException(model.Email);
            }
            
            var userNameExists = await _userRepository.GetByNameAsync(model.UserName, cancellationToken);

            if (userNameExists != null)
            {
                throw new UsernameAlreadyExistsException(model.UserName);
            }

            CreatePasswordHash(
                model.Password, 
                out var passwordHash, 
                out var passwordSalt);

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            await _userRepository.CreateAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserModel>(user);
        }

        private static void CreatePasswordHash(
            string password,
            out byte[] passwordHash,
            out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        
        private static bool VerifyPasswordHash(
            string password,
            byte[] passwordHash,
            byte[] passwordSalt)
        {
            using var hmac = new HMACSHA256(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }
    }
}