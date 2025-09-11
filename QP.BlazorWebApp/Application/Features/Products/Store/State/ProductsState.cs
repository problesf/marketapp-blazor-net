using Fluxor;
using MP;

namespace QP.BlazorWebApp.Application.Features.Products.Store.State
{
    [FeatureState]
    public record ProductsState
    {
        public bool ProductsLoading { get; init; } = false;

        public ICollection<ProductDto> Products { get; init; } = [];

    }
}
