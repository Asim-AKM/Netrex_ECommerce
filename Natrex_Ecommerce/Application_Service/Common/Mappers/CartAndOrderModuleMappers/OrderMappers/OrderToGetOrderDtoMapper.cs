using Application_Service.DTO_s.CartAndOrderDtos.OrderDtos;
using Domain_Service.Entities.CartAndOrderModule;

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
        public static IEnumerable<GetOrderDto> MapList(this IEnumerable<Order> orders)
        {
            return orders.Select(order => order.Map());
        }
    }
}
        