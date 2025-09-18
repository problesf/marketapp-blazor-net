using QP.BlazorWebApp.Application.Features.Auth.Model;

namespace QP.BlazorWebApp.Application.Features.Auth.Store.Actions
{
    public class AuthActions
    {
        public record Login(LoginModel Model);
        public record LoginSuccess(string AccessToken, String Email, ICollection<string> Roles);
        public record LoginError(string ErrorMessage);

        public record Register(RegisterModel Model);
        public record RegisterSuccess(string AccessToken, String email, ICollection<string> Roles);
        public record RegisterError(string ErrorMessage);
    }
}
