using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using QP.BlazorWebApp.Application.Features.Products.Store;

namespace QP.BlazorWebApp.Application.Features.Products.Pages
{
    public partial class Products : FluxorComponent
    {
        [Inject] private ProductsFacade Facade { get; set; }

        protected override void OnInitialized()
        {
            Facade.State.StateChanged += (_, __) =>
            {
                InvokeAsync(StateHasChanged);
            };
            base.OnInitialized();
        }
    }
}
