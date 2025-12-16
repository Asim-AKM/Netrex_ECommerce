using Application_Service.DTO_s.CartAndOrderDTOs.OrderItemDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderMappers.OrderItemMappers
{
    public static class OrderItemMapper
    {
        // AddOrderItemDto → OrderItem
        public static OrderItem ToEntity(AddOrderItemDto dto)
        {
            return new OrderItem
            {
                OrderItemId = Guid.NewGuid(),   // system-generated
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Price = dto.Price,
                PriceTotal = (decimal)(dto.Quantity * dto.Price) // calculate total
            };
        }

        // UpdateOrderItemDto → OrderItem (update existing tracked entity)
        public static void MapUpdate(UpdateOrderItemDto dto, OrderItem orderItem)
        {
            orderItem.Quantity = dto.Quantity;
            orderItem.Price = dto.Price;
            orderItem.PriceTotal = (decimal)(dto.Quantity * dto.Price); // recalc total
        }

        // OrderItem → GetOrderItemDto
        public static GetOrderItemDto ToGetDto(OrderItem orderItem)
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

        // OrderItem → UpdateOrderItemDto (optional, useful for edit forms)
        public static UpdateOrderItemDto ToUpdateDto(OrderItem orderItem)
        {
            return new UpdateOrderItemDto(
                orderItem.OrderItemId,
                orderItem.Quantity,
                orderItem.Price
            );
        }

        // OrderItem → AddOrderItemDto (optional, rarely used, e.g., cloning)
        public static AddOrderItemDto ToAddDto(OrderItem orderItem)
        {
            return new AddOrderItemDto(
                orderItem.OrderId,
                orderItem.ProductId,
                orderItem.Quantity,
                orderItem.Price
            );
        }
    }
}

