using Fluxor;
using MP;
using static QP.BlazorWebApp.Application.Features.Products.Store.Actions.ProductsActions;

namespace QP.BlazorWebApp.Application.Features.Products.Store.Effects
{
    public sealed class ProductEffects
    {
        private readonly IMPApi _api;

        public ProductEffects(IMPApi api)
        {
            _api = api;
        }

        [EffectMethod]
        public async Task HandleLoadProducts(LoadProducts action, IDispatcher dispatcher)
        {
            try
            {
                var products = await _api.ProductAllAsync(null, null, null, null, null, null, null, null, null, null, null);
                dispatcher.Dispatch(new LoadProductsSuccess(products?.ToList() ?? new List<ProductDto>()));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new LoadProductsError(ex.Message));
            }
        }
    }
}
