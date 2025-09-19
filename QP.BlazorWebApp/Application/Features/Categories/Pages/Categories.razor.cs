using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using QP.BlazorWebApp.Application.Features.Categories.Store;

namespace QP.BlazorWebApp.Application.Features.Categories.Pages
{
    public partial class Categories : FluxorComponent
    {
        [Inject] private CategoryFacade Facade { get; set; }

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
