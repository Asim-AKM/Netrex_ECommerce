using Application_Service.DTO_s.CartDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartMappers
{
    public static class UpdateCartMapper
    {
        public static Cart Map(this UpdateCartDto dto)
        {
            return new Cart
            {
                CartId= dto.CartId,
                CustomerId= dto.CustomerId,
            };
        }

        public static UpdateCartDto MapToUpdateCartDto(this Cart cart)
        {
            return new UpdateCartDto
                (
                cart.CartId,
                cart.CustomerId
                );
        }
    }
}
