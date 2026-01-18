using Application_Service.DTO_s.Cart_OrderDtos.CartDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartMappers
{
    public static class UpdateCartDtoToCartMapper
    {
        public static Cart Map(this UpdateCartDto updateCartDto)
        {
            return new Cart
            {
                CartId = updateCartDto.CartId,
                CustomerId = updateCartDto.CustomerId
            };
        }

    }
}
