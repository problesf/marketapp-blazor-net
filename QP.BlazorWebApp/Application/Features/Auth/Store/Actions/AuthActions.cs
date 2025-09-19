using QP.BlazorWebApp.Application.Features.Auth.Model;

namespace QP.BlazorWebApp.Application.Features.Auth.Store.Actions
{
    public class AuthActions
    {
        public record Login(LoginModel Model);
        public record LoginSuccess(string AccessToken, string Email, long ProfileId, ICollection<string> Roles);
        public record LoginError(string ErrorMessage);

        public record Register(RegisterModel Model);
        public record RegisterSuccess(string AccessToken, string Email, long ProfileId, ICollection<string> Roles);
        public record RegisterError(string ErrorMessage);

        public record Logout();

    }
}
