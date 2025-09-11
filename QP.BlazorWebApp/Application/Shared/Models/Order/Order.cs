using MarketApp.src.Domain.enums;
using QP.BlazorWebApp.Application.Shared.Models.Customers;

namespace QP.BlazorWebApp.Application.Shared.Models.Order
{
    public class Order
    {
        public long Id { get; set; }

        public int OrderNumber { get; set; }

        public long CustomerId { get; set; }

        public Status Status { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TaxTotal { get; set; }

        public decimal ShippingTotal { get; set; }

        public decimal DiscountTotal { get; set; }

        public decimal GrandTotal { get; set; }

        public string Currency { get; set; }

        public DateTime PlaceAt { get; set; }

        public DateTime? PaidAt { get; set; }

        public DateTime? CancelledAt { get; set; }

        public DateTime? DeliveredAt { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public ICollection<Shipment> Shipments { get; set; }
        public Address ShippingAddressSnapshot { get; }
        public Address BillingAddressSnapshot { get; }
    }
}
