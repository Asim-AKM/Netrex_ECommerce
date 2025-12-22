using Application_Service.DTO_s.Cart_OrderDtos.OrderDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderMappers
{
    public static class UpdateOrderDtoToOrderMapper
    {
        public static Order Map(this UpdateOrderDto updateOrderDto)
        {
            return new Order
            {
                OrderId = updateOrderDto.OrderId,
                OrderStatus = updateOrderDto.OrderStatus,
                PaymentStatus = updateOrderDto.PaymentStatus
            };
        }
    }
}
