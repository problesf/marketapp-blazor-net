using Fluxor;

namespace QP.BlazorWebApp.Application.Features.Auth.Store.State
{
    [FeatureState]
    public record AuthState
    {
        public bool IsHydrated { get; set; } = false;
        public long ProfileId { get; init; }
        public bool AuthLoading { get; init; } = false;
        public bool IsAuthenticated { get; init; } = false;

        public string Email { get; init; }
        public string? AccessToken { get; set; }

        public ICollection<String> Roles { get; init; } = [];

    }
}
