namespace Application_Service.DTO_s.UserManagmentDto_s.WishList
{
    public record GetWishListItem(Guid WishListItemId, Guid Product, Guid ImgeId, string? ImageUrl, string? CloudPublicId, Guid SellerId, Guid ProductcatorgayId, string ProductName, string ProductDescription, double Price, double Discount);
}
