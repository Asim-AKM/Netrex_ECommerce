using Application_Service.DTO_s.CartAndOrderDtos.OrderItemDtos;
using Domain_Service.Entities.CartAndOrderModule;

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
        public static IEnumerable<GetOrderItemDto> MapList(this IEnumerable<OrderItem> orderItems)
        {
            return orderItems.Select(oi => oi.Map());
        }
    }
}
