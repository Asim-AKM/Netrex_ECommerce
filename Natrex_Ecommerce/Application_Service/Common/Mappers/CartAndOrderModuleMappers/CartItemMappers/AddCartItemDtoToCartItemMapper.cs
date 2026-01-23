using Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos;
using Domain_Service.Entities.CartAndOrderModule;

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
