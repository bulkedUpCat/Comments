using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Comments.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Comments.Infrastructure.Auth.Interfaces
{
    public interface IJwtHandler
    {
        SigningCredentials GetSigningCredentials();
        List<Claim> GetClaims(User user);
        JwtSecurityToken GenerateToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims);
    }
}