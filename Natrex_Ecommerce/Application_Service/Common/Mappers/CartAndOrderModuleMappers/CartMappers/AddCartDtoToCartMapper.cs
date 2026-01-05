using Application_Service.DTO_s.CartAndOrderDtos.CartDtos;
using Domain_Service.Entities.CartAndOrderModule;

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
