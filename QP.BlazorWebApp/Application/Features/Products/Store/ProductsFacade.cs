using Fluxor;
using MP;
using QP.BlazorWebApp.Application.Features.Products.Store.State;
using static QP.BlazorWebApp.Application.Features.Products.Store.Actions.ProductsActions;

namespace QP.BlazorWebApp.Application.Features.Products.Store
{
    public class ProductsFacade
    {
        private readonly IState<ProductsState> _state;
        private readonly IDispatcher _dispatcher;

        public ProductsFacade(IState<ProductsState> state, IDispatcher dispatcher)
        {
            _state = state;
            _dispatcher = dispatcher;
        }

        public IState<ProductsState> State => _state;

        public bool IsLoading => _state.Value.ProductsLoading;
        public ICollection<ProductDto> Products => _state.Value.Products;

        public void LoadProducts() => _dispatcher.Dispatch(new LoadProducts());

        public void CreateProduct(ProductDto product) => _dispatcher.Dispatch(new CreateProduct(product));
    }

}
