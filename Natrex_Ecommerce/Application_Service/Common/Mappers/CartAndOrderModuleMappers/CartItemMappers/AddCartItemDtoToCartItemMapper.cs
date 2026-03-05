namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartItemMappers
{
    public static class AddCartItemDtoToCartItemMapper
    {
        public static CartItem Map(this AddCartItemDto addCartItemDto,Guid cartId)
        {
            return new CartItem
            {
                CartItemId = Guid.NewGuid(),
                CartId = cartId,
                ProductId = addCartItemDto.ProductId,
                Quantity = addCartItemDto.Quantity
            };
        }
    }
}
