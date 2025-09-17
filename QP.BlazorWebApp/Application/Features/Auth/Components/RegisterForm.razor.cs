using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using QP.BlazorWebApp.Application.Features.Auth.Enum;
using QP.BlazorWebApp.Application.Features.Auth.Model;
using QP.BlazorWebApp.Application.Features.Auth.Store;

namespace QP.BlazorWebApp.Application.Features.Auth.Components
{
    public partial class RegisterForm : FluxorComponent
    {
        [Inject]
        private AuthFacade Facade { get; set; } = default!;
        RegisterModel model;

        private MudForm? _form;

        private IEnumerable<string> StoreNameRules(string? value)
        {
            if (model.UserType == UserType.Vendedor && string.IsNullOrWhiteSpace(value))
                yield return "El nombre de la tienda es obligatorio para vendedores.";
        }

        private async Task OnUserTypeChanged(UserType value)
        {
            model.UserType = value;
            if (_form is not null)
                await _form.Validate();
        }

        private async Task SubmitAsync()
        {
            if (_form is null) return;
            await _form.Validate();
            if (_form.IsValid)
            {
                Facade.Register(model);
            }
        }
        protected override void OnInitialized()
        {
            model = new RegisterModel();
            base.OnInitialized();
        }
    }
}
