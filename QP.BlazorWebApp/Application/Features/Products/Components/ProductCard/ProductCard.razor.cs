using Microsoft.AspNetCore.Components;
using MP;

namespace QP.BlazorWebApp.Application.Features.Products.Components.ProductCard
{
    public partial class ProductCard
    {
        [Parameter] public ProductDto product { get; set; }

    }
}
