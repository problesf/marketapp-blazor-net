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
                var products = await _api.ProductsAllAsync(null, null, null, null, null, null, null, null, null, null, null, null);
                dispatcher.Dispatch(new LoadProductsSuccess(products?.ToList() ?? new List<ProductDto>()));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new LoadProductsError(ex.Message));
            }
        }

        [EffectMethod]
        public async Task HandleCreateProduct(CreateProduct action, IDispatcher dispatcher)
        {
            Boolean haveCategories = action.Product.Categories != null && action.Product.Categories.Count != 0;
            try
            {
                CreateProductCommand command = new()
                {
                    Code = action.Product.Code,
                    Name = action.Product.Name,
                    Description = action.Product.Description,
                    Price = action.Product.Price,
                    Currency = action.Product.Currency,
                    Stock = action.Product.Stock,
                    TaxRate = action.Product.TaxRate,
                    CategoriesId = haveCategories ? action.Product.Categories.Where(c => c.Id.HasValue).Select(c => c.Id.Value).ToList() : null
                };
                var productId = await _api.ProductsPOSTAsync(command);
                action.Product.Id = productId;
                dispatcher.Dispatch(new CreateProductSuccess(action.Product));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new CreateProductError(ex.Message));
            }
        }
    }
}
