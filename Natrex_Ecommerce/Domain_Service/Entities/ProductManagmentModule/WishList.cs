namespace Domain_Service.Entities.ProductManagmentModule
{
    public class WishList
    {
        [Key]
        public Guid WishListId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CrestedAt { get; set; }

    }
}
