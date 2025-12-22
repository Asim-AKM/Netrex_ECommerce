using Application_Service.DTO_s.Cart_OrderDtos.CartItemDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
