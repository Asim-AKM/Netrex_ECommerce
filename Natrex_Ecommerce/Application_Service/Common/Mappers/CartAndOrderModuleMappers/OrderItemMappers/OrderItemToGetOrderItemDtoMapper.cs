using Application_Service.DTO_s.Cart_OrderDtos.OrderItemDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderItemMappers
{
    public static class OrderItemToGetOrderItemDtoMapper
    {
        public static GetOrderItemDto Map(this OrderItem orderItem)
        {
            return new GetOrderItemDto(
                orderItem.OrderItemId,
                orderItem.OrderId,
                orderItem.ProductId,
                orderItem.Quantity,
                orderItem.Price,
                orderItem.PriceTotal
            );
        }
    }
}
