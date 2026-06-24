using Application_Service.DTO_s.CartAndOrderDTOs.OrderDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderMappers.OrderMappers
{
    public static class OrderMapper
    {
        // AddOrderDto → Order
        public static Order MapToEntity(AddOrderDto dto)
        {
            return new Order
            {
                OrderId = Guid.NewGuid(),      // system-generated
                CustomerId = dto.CustomerId,
                TotalAmount = dto.TotalAmount,
                OrderStatus = false,           // default initial status
                PaymentStatus = false,         // default initial status
                CreatedAt = DateTime.UtcNow    // set creation time
            };
        }

        // UpdateOrderDto → Order (update existing tracked entity)
        public static void MapUpdate(UpdateOrderDto dto, Order order)
        {
            order.OrderStatus = dto.OrderStatus;
            order.PaymentStatus = dto.PaymentStatus;
            // OrderId, CustomerId, TotalAmount, CreatedAt are system-generated / immutable
        }

        // Order → GetOrderDto
        public static GetOrderDto MapToGetDto(Order order)
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

        // Order → UpdateOrderDto (optional, useful for edit forms)
        public static UpdateOrderDto MapToUpdateDto(Order order)
        {
            return new UpdateOrderDto(
                order.OrderId,
                order.OrderStatus,
                order.PaymentStatus
            );
        }

        // Order → AddOrderDto (optional, rarely used)
        public static AddOrderDto MapToAddDto(Order order)
        {
            return new AddOrderDto(
                order.CustomerId,
                order.TotalAmount
            );
        }
    }
}

