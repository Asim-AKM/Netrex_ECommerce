using Application_Service.DTO_s.Cart_OrderDtos.CartItemDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartItemMappers
{
    public static class AddCartItemDtoToCartItemMapper
    {
        public static CartItem Map(this AddCartItemDto addCartItemDto)
        {
            return new CartItem
            {
                CartItemId = Guid.NewGuid(),
                CartId = addCartItemDto.CartId,
                ProductId = addCartItemDto.ProductId,
                Quantity = addCartItemDto.Quantity
            };
        }
    }
}
