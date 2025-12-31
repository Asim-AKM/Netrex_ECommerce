using Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos;
using Domain_Service.Entities.CartAndOrderModule;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartItemMappers
{
    public static class UpdateCartItemDtoToCartItemMapper
    {
        public static CartItem Map(this UpdateCartItemDto updateCartItemDto)
        {
            return new CartItem
            {
                CartItemId = updateCartItemDto.CartItemId,
                Quantity = updateCartItemDto.Quantity
            };
        }
    }
}
