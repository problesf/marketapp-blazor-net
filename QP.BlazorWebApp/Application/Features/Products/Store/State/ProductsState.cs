using Fluxor;
using MP;

namespace QP.BlazorWebApp.Application.Features.Products.Store.State
{
    [FeatureState]
    public record ProductsState
    {
        public bool ProductsLoading { get; init; } = true;

        public ICollection<ProductDto> Products { get; init; } = [];

    }
}
