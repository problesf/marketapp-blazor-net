using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MP;
using MudBlazor;
using QP.BlazorWebApp.Application.Features.Products.Components;
using QP.BlazorWebApp.Application.Features.Products.Store;
using QP.BlazorWebApp.Application.Features.Products.Store.State;

namespace QP.BlazorWebApp.Application.Features.Products.Pages
{
    public partial class ProductsList : FluxorComponent
    {
        [Inject] private ProductsFacade Facade { get; set; }
        [Inject] private Fluxor.IState<ProductsState> ProductsState { get; set; }
        [Inject] private IDialogService DialogService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                Facade.LoadProducts();
        }

        private async Task OpenCreateDialog()
        {
            var options = new DialogOptions
            {
                CloseButton = true,
                FullWidth = true,
                MaxWidth = MaxWidth.Medium
            };

            var dialog = DialogService.Show<ProductManagementDialog>(
                "ProductManagement",
                new DialogParameters(),
                options
            );

            var result = await dialog.Result;

            if (!result.Canceled && result.Data is ProductDto dto)
            {
                Facade.CreateProduct(dto);
            }
        }
    }
}
