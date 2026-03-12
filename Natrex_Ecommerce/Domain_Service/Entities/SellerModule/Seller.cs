namespace Domain_Service.Entities.SellerModule
{
    public class Seller
    {
        [Key]
        public Guid SellerId { get; set; }
        public Guid UserId { get; set; }
        public Guid ShopId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string StoreDescription { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public SellerStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
