using Application_Service.DTO_s.CartDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartMappers
{
    public static class AddCartMapper
    {
        public static Cart Map(this AddCartDto dto)
        {
            return new Cart
            {
                CartId = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),

            };
        }

        public static AddCartDto MapToDto(this Cart cart)
        {
            return new AddCartDto
                 (

                cart.CartId,
                cart.CustomerId

                );
        }
    }
}
