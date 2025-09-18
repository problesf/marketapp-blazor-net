namespace QP.BlazorWebApp.Application.Features.Auth.Store.State
{
    public sealed class AuthSnapshot
    {
        public string? Token { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
    }
}
