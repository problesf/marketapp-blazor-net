using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using QP.BlazorWebApp.Application.Features.Auth.Store;
using QP.BlazorWebApp.Application.Features.Products.Store;

namespace QP.BlazorWebApp.Application.Shared.Components
{

    public partial class LoadingOverlay : FluxorComponent
    {
        [Inject] protected ProductsFacade ProductsFacade { get; set; } = default!;
        [Inject] protected AuthFacade AuthFacade { get; set; } = default!;
		
        protected bool IsLoading =>
            ProductsFacade.IsLoading || AuthFacade.IsLoading;
    }

}
