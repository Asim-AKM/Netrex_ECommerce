namespace Domain_Service.Entities.SellerModule
{
    public class Seller
    {
        public Guid SellerId { get; set; }
        public Guid UserId { get; set; }
        public Guid ShopId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string StoreDescription { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int GstNumber { get; set; }

    }
}
