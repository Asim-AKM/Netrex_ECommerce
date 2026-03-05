namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartMappers
{
    public static class UpdateCartDtoToCartMapper
    {
        public static Cart Map(this UpdateCartDto dto)
        {
            return new Cart
            {
                CartId = dto.CartId,
                CustomerId = dto.CustomerId
            };

        }

    }
}
