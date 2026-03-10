namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartItemMappers
{
    public static class CartItemToGetCartItemDtoMapper
    {
        public static GetCartItemDto Map(this CartItem cartItem,Product product,string image)
        {
            return new GetCartItemDto(cartItem.CartItemId,product.ProductName,product.ProductDescription,product.Price,image,cartItem.Quantity);
        }
    }
}
