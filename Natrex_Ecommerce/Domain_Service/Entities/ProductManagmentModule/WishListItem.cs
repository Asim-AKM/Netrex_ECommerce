namespace Domain_Service.Entities.ProductManagmentModule
{
    public class WishListItem
    {
        [Key]
        public Guid WishListItemId { get; set; }
        public Guid ProductId { get;set; }
        public Guid WishListId { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
