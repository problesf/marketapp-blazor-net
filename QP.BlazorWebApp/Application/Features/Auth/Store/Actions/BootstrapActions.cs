namespace QP.BlazorWebApp.Application.Features.Auth.Store.Actions
{
    public static class BootstrapActions
    {
        public sealed record HydrateAuthFromStorage();
        public sealed record HydrateAuthSuccess(string Token, string? Email, IReadOnlyCollection<string>? Roles);
        public sealed record HydrateAuthNone();
    }
}
