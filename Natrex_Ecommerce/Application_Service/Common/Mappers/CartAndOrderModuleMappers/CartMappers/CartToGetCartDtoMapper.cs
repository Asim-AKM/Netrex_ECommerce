using Application_Service.DTO_s.CartAndOrderDtos.CartDtos;
using Domain_Service.Entities.CartAndOrderModule;

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
