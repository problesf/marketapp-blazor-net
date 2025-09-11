using QP.BlazorWebApp.Application.Shared.Models.Customers;
using QP.BlazorWebApp.Application.Shared.Models.Products;

namespace QP.BlazorWebApp.Application.Shared.Models.Reviews
{
    public class Review
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public long CustomerId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public bool isApproved { get; set; }

        public DateTime CreatedAt { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }


    }
}
