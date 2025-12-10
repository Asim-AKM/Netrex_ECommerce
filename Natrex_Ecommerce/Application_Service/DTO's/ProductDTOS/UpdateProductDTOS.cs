namespace Application_Service.DTO_s.ProductDTOS
{
    public class UpdateProductDTOS
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int StockQuantity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
