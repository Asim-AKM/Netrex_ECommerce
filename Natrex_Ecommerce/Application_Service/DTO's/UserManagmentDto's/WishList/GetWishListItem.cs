namespace Application_Service.DTO_s.UserManagmentDto_s.WishList
{
    public record GetWishListItem(Guid WishListItemId, Guid ProductId, Guid ImgeId, string? ImageUrl, string? CloudPublicId, Guid SellerId, string ProductName, string ProductDescription, double Price, double Discount);
}
