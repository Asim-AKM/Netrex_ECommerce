namespace Application_Service.DTO_s.UserManagmentDto_s.WishList
{
    public record AddWishListItemDto(Guid ProductId)
    {
        public Guid UserId { get; init; } =
            Guid.Parse("4818cc53-f71a-4bfe-97f0-2453268a22a0");
    }
}