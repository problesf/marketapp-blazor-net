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

        [ReducerMethod]
        public static ProductsState ReduceCreateProduct(ProductsState state, CreateProduct action)
        {
            return state with { ProductsLoading = true };


        }
        [ReducerMethod]
        public static ProductsState ReduceCreateProductSuccess(ProductsState state, CreateProductSuccess action)
        {
            return state with
            {
                ProductsLoading = false,
                Products = [.. state.Products, action.Product]
            };
        }


        [ReducerMethod]
        public static ProductsState ReduceCreateProductError(ProductsState state, CreateProductError action)
        {
            return state with { ProductsLoading = false };

        }
    }
}
