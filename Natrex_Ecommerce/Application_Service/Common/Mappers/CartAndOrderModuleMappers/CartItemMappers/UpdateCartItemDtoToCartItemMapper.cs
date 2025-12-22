using Application_Service.DTO_s.Cart_OrderDtos.CartItemDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
