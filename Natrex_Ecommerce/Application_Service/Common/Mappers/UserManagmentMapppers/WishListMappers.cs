namespace Application_Service.Common.Mappers.UserManagmentMapppers
{
    public static class WishListMappers
    {
        public static WishListItem ToWishListItem(this AddWishListItemDto request, Guid wishListId)
        {
            return new WishListItem
            {
                WishListItemId = Guid.NewGuid(),
                WishListId = wishListId,
                ProductId = request.ItemId,
                AddedAt = DateTime.UtcNow
            };
        }

        public static WishList ToWishList(this AddWishListItemDto request)
        {
            return new WishList
            {
                WishListId = Guid.NewGuid(),
                UserId = request.UserId,
                CrestedAt = DateTime.UtcNow
            };
        }

        public static List<GetWishListItem> ToWishListItemList(List<WishListItem> listItems)
        {
            throw new NotImplementedException();
        }
    }
}
