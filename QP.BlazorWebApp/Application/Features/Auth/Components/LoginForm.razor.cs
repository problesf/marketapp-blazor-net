using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using QP.BlazorWebApp.Application.Features.Auth.Model;
using QP.BlazorWebApp.Application.Features.Auth.Store;

namespace QP.BlazorWebApp.Application.Features.Auth.Components
{
    public partial class LoginForm : FluxorComponent
    {
        [Inject]
        private AuthFacade Facade { get; set; } = default!;
        LoginModel model;

        [Inject] private NavigationManager Navigation { get; set; } = default!;

        MudForm? _form;
        protected override void OnInitialized()
        {
            model = new LoginModel();
            base.OnInitialized();
        }

        private async Task SubmitAsync()
        {
            if (_form is null) return;
            await _form.Validate();
            if (_form.IsValid)
            {
                Facade.Login(model);
            }
        }

    }
}

