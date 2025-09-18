using Fluxor;
using Microsoft.AspNetCore.Components;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;


namespace QP.BlazorWebApp.Application.Core.Components
{
    public partial class NavMenu
    {
        [Inject] private IState<AuthState> Auth { get; set; } = default!;

        private bool collapseNavMenu = true;
        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu() => collapseNavMenu = !collapseNavMenu;
    }
}
