using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace QP.BlazorWebApp.Application.Core.Services.Impl
{
    public class TokenServiceImpl : ITokenService
    {
        private readonly JwtSecurityTokenHandler _handler = new JwtSecurityTokenHandler();

        public ClaimsPrincipal Decode(string jwtToken)
        {
            var token = _handler.ReadJwtToken(jwtToken);

            var identity = new ClaimsIdentity(token.Claims, "jwt");
            return new ClaimsPrincipal(identity);
        }

        public JwtSecurityToken ReadToken(string jwtToken)
        {
            return _handler.ReadJwtToken(jwtToken);
        }

        public bool IsExpired(string jwtToken)
        {
            var token = ReadToken(jwtToken);

            var expiry = token.ValidTo;

            return expiry < DateTime.UtcNow;
        }

        public List<string> GetRoles(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = ReadToken(jwtToken);

            var roles = token.Claims.Where(c => c.Type == ClaimTypes.Role)
                             .Select(c => c.Value)
                             .ToList();

            return roles;
        }
    }
}
