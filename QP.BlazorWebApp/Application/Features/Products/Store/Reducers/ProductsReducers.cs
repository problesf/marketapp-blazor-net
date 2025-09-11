using Fluxor;
using QP.BlazorWebApp.Application.Features.Products.Store.State;
using static QP.BlazorWebApp.Application.Features.Products.Store.Actions.ProductsActions;

namespace QP.BlazorWebApp.Application.Features.Products.Store.Reducers
{
    public static class ProductsReducers
    {
        [ReducerMethod]
        public static ProductsState ReduceLoadProducts(ProductsState state, LoadProducts action)
        {
            return state with { ProductsLoading = true };


        }
        [ReducerMethod]
        public static ProductsState ReduceLoadProductsSuccess(ProductsState state, LoadProductsSuccess action)
        {
            return state with { ProductsLoading = false, Products = action.Products };
        }


        [ReducerMethod]
        public static ProductsState ReduceLoadProductsError(ProductsState state, LoadProductsError action)
        {
            return state with { ProductsLoading = false };

        }
    }
}
