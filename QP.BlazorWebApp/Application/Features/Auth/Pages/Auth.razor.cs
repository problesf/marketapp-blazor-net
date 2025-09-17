using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;

namespace QP.BlazorWebApp.Application.Features.Auth.Pages
{
    public partial class Auth : FluxorComponent
    {
        [Inject] private NavigationManager Nav { get; set; } = default!;


        private bool IsLogin;

        protected override void OnInitialized()
        {
            var uri = Nav.Uri.ToLower();

            if (uri.Contains("/login"))
                IsLogin = true;
            else if (uri.Contains("/register"))
                IsLogin = false;
            base.OnInitialized();
        }
    }
}
