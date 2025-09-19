using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace QP.BlazorWebApp.Application.Core.Services
{
    public interface ITokenService
    {
        ClaimsPrincipal Decode(string jwtToken);
        JwtSecurityToken ReadToken(string jwtToken);
        bool IsExpired(string jwtToken);
        List<string> GetRoles(string jwtToken);

    }
}
