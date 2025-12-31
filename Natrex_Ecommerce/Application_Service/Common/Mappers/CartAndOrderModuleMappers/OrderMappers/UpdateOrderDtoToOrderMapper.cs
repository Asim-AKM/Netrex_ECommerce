using Application_Service.DTO_s.CartAndOrderDtos.OrderDtos;
using Domain_Service.Entities.CartAndOrderModule;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderMappers
{
    public static class UpdateOrderDtoToOrderMapper
    {
        public static Order Map(this UpdateOrderDto updateOrderDto)
        {
            return new Order
            {
                OrderId = updateOrderDto.OrderId,
                OrderStatus = updateOrderDto.OrderStatus,
                PaymentStatus = updateOrderDto.PaymentStatus
            };
        }
    }
}
