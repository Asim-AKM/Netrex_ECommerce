namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartMappers
{
    public static class CartToGetCartDtoMapper
    {
        public static GetCartDto Map(this Cart cart)
        {
            return new GetCartDto(cart.CartId, cart.CustomerId);
        }
    }
}
