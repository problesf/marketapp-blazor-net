using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace QP.BlazorWebApp.Application.Features.Auth.Pages
{
    public partial class Auth : FluxorComponent, IDisposable
    {
        [Inject] private NavigationManager Nav { get; set; } = default!;

        private bool IsLogin;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            UpdateIsLogin(Nav.Uri);

            Nav.LocationChanged += OnLocationChanged;
        }

        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            var changed = UpdateIsLogin(e.Location);

            if (changed)
                InvokeAsync(StateHasChanged);
        }

        private bool UpdateIsLogin(string? absoluteUri)
        {
            var path = Nav.ToBaseRelativePath(absoluteUri ?? string.Empty)
                          .ToLowerInvariant();

            bool newIsLogin = path.StartsWith("login") || path.Contains("/login");
            bool isRegister = path.StartsWith("register") || path.Contains("/register");

            bool shouldUpdate = newIsLogin || isRegister;

            if (shouldUpdate && newIsLogin != IsLogin)
            {
                IsLogin = newIsLogin;
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            Nav.LocationChanged -= OnLocationChanged;
        }
    }
}
