using Application_Service.DTO_s.CartAndOrderDtos.OrderItemDtos;
using Domain_Service.Entities.CartAndOrderModule;

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
                PriceTotal = addOrderItemDto.Price * addOrderItemDto.Quantity
            };
        }

    }
}
