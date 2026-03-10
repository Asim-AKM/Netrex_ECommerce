namespace Application_Service.DTO_s.UserManagmentDto_s.WishList
{
    public record AddWishListItemDto(Guid ProductId)
    {
        public Guid UserId { get; init; } 
    }
}

