using Application_Service.DTO_s.Cart_OrderDtos.OrderItemDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderItemMappers
{
    public static class UpdateOrderItemDtoToOrderItemMapper
    {
        public static OrderItem Map(this UpdateOrderItemDto updateOrderItemDto)
        {
            return new OrderItem
            {
                OrderItemId = updateOrderItemDto.OrderItemId,
                Quantity = updateOrderItemDto.Quantity,
                Price = updateOrderItemDto.Price,
                PriceTotal =updateOrderItemDto.Price * updateOrderItemDto.Quantity
            };
        }
    }
}
