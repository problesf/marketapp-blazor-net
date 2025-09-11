using QP.BlazorWebApp.Application.Shared.Models.Reviews;

namespace QP.BlazorWebApp.Application.Shared.Models.Customers
{
    public class Customer
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public long DefaultBillingAddressId { get; set; }

        public Address DefaultBillingAddress { get; set; }

        public long DefaultShippingAddressId { get; set; }

        public Address DefaultShippingAddress { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
