using MarketApp.src.Domain.enums;
using QP.BlazorWebApp.Application.Shared.Models.Products;

namespace QP.BlazorWebApp.Application.Shared.Models.Inventory
{
    public class InventoryMovement
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public Reason Reason { get; set; }

        public string Reference { get; set; }
    }
}
