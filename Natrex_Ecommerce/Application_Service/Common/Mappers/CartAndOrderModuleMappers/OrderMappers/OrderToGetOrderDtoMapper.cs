using Application_Service.DTO_s.Cart_OrderDtos.OrderDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderMappers
{
    public static class OrderToGetOrderDtoMapper
    {
        public static GetOrderDto Map(this Order order)
        {
            return new GetOrderDto(
                order.OrderId,
                order.CustomerId,
                order.OrderStatus,
                order.PaymentStatus,
                order.TotalAmount,
                order.CreatedAt
            );
        }

    }
}
