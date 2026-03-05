namespace Domain_Service.Entities.SellerModule
{
    public class ShopDetail
    {
        [Key]
        public Guid ShopDetailsId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
