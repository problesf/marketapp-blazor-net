using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MP;
using MudBlazor;
using QP.BlazorWebApp.Application.Features.Auth.Store;
using QP.BlazorWebApp.Application.Features.Categories.Store;
using QP.BlazorWebApp.Application.Features.Products.Components;
using QP.BlazorWebApp.Application.Features.Products.Store;

namespace QP.BlazorWebApp.Application.Features.Products.Pages
{
    public partial class ProductsManagement : FluxorComponent
    {
        List<ProductDto> SellerProducts { get; set; } = [];
        [Inject] private ProductsFacade Facade { get; set; }

        [Inject] private CategoryFacade CategoryFacade { get; set; }


        [Inject] private AuthFacade Auth { get; set; }

        [Inject] private IDialogService DialogService { get; set; }

        protected override void OnInitialized()
        {
            SellerProducts = Facade.Products
                                   .Where(p => p.SellerProfileId == Auth.ProfileId)
                                   .ToList();

            Facade.State.StateChanged += (_, __) =>
            {
                InvokeAsync(StateHasChanged);
            };
            base.OnInitialized();
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
                new DialogParameters { ["Categories"] = CategoryFacade.Categories },
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
