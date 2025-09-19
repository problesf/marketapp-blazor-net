using Microsoft.AspNetCore.Components;
using QP.BlazorWebApp.Application.Features.Auth.Store;

namespace QP.BlazorWebApp.Application.Core.Components
{
    public partial class ResponsiveNav : ComponentBase
    {
        [Inject] public NavigationManager Nav { get; set; } = default!;
        [Inject] public AuthFacade Auth { get; set; } = default!;
        [Parameter] public EventCallback OnLogout { get; set; }

        private bool _drawerOpen = true;

        private void ToggleDrawer() => _drawerOpen = !_drawerOpen;


        private async Task Logout()
        {
            Auth.Logout();
        }

        protected override void OnInitialized()
        {
            Auth.State.StateChanged += (_, __) =>
            {
                InvokeAsync(StateHasChanged);
            };
            base.OnInitialized();
        }
    }
}
