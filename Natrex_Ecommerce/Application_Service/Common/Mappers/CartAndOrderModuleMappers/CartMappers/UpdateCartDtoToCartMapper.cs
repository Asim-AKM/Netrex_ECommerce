using Application_Service.DTO_s.CartAndOrderDtos.CartDtos;
using Domain_Service.Entities.CartAndOrderModule;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartMappers
{
    public static class UpdateCartDtoToCartMapper
    {
        public static Cart Map(this UpdateCartDto dto,Cart cart)
        {
                cart.CustomerId = dto.CustomerId;
                return cart;
             
        }

    }
}
