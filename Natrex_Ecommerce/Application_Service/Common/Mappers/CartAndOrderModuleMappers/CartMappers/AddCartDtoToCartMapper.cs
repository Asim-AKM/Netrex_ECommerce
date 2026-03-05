namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartMappers
{
    public static class AddCartDtoToCartMapper
    {
        public static Cart Map(this AddCartDto addCartDto)
        {
            return new Cart
            {
                CartId = Guid.NewGuid(),
                CustomerId = addCartDto.CustomerId
            };
        }
    }
}
