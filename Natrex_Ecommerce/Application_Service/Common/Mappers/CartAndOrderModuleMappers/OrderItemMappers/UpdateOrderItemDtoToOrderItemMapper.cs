using Application_Service.DTO_s.CartAndOrderDtos.OrderItemDtos;
using Domain_Service.Entities.CartAndOrderModule;

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
