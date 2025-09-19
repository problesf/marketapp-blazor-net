using Fluxor;
using MP;

namespace QP.BlazorWebApp.Application.Features.Categories.Store.State
{
    [FeatureState]
    public record CategoryState
    {
        public bool CategoriesLoading { get; init; } = true;
        public ICollection<CategoryDto> Categories { get; init; }

    }
}
