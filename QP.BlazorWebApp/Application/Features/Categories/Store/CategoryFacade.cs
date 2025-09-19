using Fluxor;
using MP;
using QP.BlazorWebApp.Application.Features.Categories.Store.State;
using static QP.BlazorWebApp.Application.Features.Categories.Store.Actions.CategoryActions;

namespace QP.BlazorWebApp.Application.Features.Categories.Store
{
    public class CategoryFacade
    {
        private readonly IState<CategoryState> _state;
        private readonly IDispatcher _dispatcher;

        public CategoryFacade(IState<CategoryState> state, IDispatcher dispatcher)
        {
            _state = state;
            _dispatcher = dispatcher;
        }

        public IState<CategoryState> State => _state;

        public bool IsLoading => _state.Value.CategoriesLoading;
        public ICollection<CategoryDto> Categories => _state.Value.Categories;

        public void LoadCategories() => _dispatcher.Dispatch(new LoadCategories());

        public void CreateCategory(CategoryDto category) => _dispatcher.Dispatch(new CreateCategory(category));
    }
}
