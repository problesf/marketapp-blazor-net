using MP;

namespace QP.BlazorWebApp.Application.Features.Products.Store.Actions
{
    public class ProductsActions
    {
        public record LoadProducts();
        public record LoadProductsSuccess(ICollection<ProductDto> Products);
        public record LoadProductsError(string ErrorMessage);

        public record CreateProduct(ProductDto Product);
        public record CreateProductSuccess(ProductDto Product);
        public record CreateProductError(string ErrorMessage);

    }
}
