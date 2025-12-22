using Application_Service.DTO_s.Cart_OrderDtos.OrderItemDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderItemMappers
{
    public static class AddOrderItemDtoToOrderItemMapper
    {
        public static OrderItem Map(this AddOrderItemDto addOrderItemDto)
        {
            return new OrderItem
            {
                OrderItemId = Guid.NewGuid(),
                OrderId = addOrderItemDto.OrderId,
                ProductId = addOrderItemDto.ProductId,
                Quantity = addOrderItemDto.Quantity,
                Price = addOrderItemDto.Price,
                PriceTotal = (decimal)addOrderItemDto.Price * addOrderItemDto.Quantity
            };
        }

    }
}
