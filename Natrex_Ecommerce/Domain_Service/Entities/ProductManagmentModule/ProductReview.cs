namespace Domain_Service.Entities.ProductManagmentModule
{
    public class ProductReview
    {
        public Guid ReviewId { get; set; }

        public Guid ProductId { get; set; }

        public Guid CustomerId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;

        public bool IsApproved { get; set; }

        public string IPAddress { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
