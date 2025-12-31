using Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos;
using Domain_Service.Entities.CartAndOrderModule;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartItemMappers
{
    public static class CartItemToGetCartItemDtoMapper
    {
        public static GetCartItemDto Map(this CartItem cartItem)
        {
            return new GetCartItemDto(cartItem.CartItemId, cartItem.CartId, cartItem.ProductId, cartItem.Quantity);
        }
    }
}
