using Application_Service.DTO_s.CartDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartMappers
{
    public static class GetCartMapper
    {
        public static GetCartDto Map(this Cart cart)
        {
            return new GetCartDto
            (
                cart.CartId,
                cart.CustomerId
                );
        }
    }
}
