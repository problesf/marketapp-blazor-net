

using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MP;
using MudBlazor;
using QP.BlazorWebApp.Application.Features.Products.Store;

namespace QP.BlazorWebApp.Application.Features.Products.Components
{
    public partial class ProductsList : FluxorComponent
    {
        [Inject] private ProductsFacade Facade { get; set; }
        [Parameter] public List<ProductDto> Products { get; set; } = new();
        [Inject] private IDialogService DialogService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

    }
}
