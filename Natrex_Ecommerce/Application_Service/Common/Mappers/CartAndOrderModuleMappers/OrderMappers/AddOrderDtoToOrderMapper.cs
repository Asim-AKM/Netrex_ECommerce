using Application_Service.DTO_s.Cart_OrderDtos.OrderDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderMappers
{
    public static class AddOrderDtoToOrderMapper
    {
        public static Order Map(this AddOrderDto addOrderDto)
        {
            return new Order
            {
                OrderId = Guid.NewGuid(),
                CustomerId = addOrderDto.CustomerId,
                OrderStatus = false,
                PaymentStatus = false,
                TotalAmount = addOrderDto.TotalAmount,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
