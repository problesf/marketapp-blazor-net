using Fluxor;

namespace QP.BlazorWebApp.Application.Features.Auth.Store.State
{
    [FeatureState]
    public record AuthState
    {
        public bool AuthLoading { get; init; } = false;

        public string? AccessToken { get; set; }

        public ICollection<String> Roles { get; init; } = [];

    }
}
