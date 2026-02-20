namespace Application_Service.DTO_s.ProductDTOS
{
    public class GetProductDto()
    {
        public Guid productId { get; set; }
        public Guid ImgeId { get; set; }
        public Guid sellerId { get; set; }
        public Guid productcatorgayId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public int stockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public string? CloudPublicId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public List<ImagesDto> Images { get; set; }
        public double FinalPrice => price - (price * discount / 100);
        public int TotalViews { get; set; }
        public decimal AverageRating { get; set; }
        public int TotalReviews { get; set; }
    };


}
