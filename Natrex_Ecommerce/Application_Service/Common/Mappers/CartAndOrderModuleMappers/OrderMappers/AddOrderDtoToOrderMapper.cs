using Application_Service.DTO_s.CartAndOrderDtos.OrderDtos;
using Domain_Service.Entities.CartAndOrderModule;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderMappers
{
    public static class AddOrderDtoToOrderMapper
    {
        public static Order Map(this AddOrderDto addOrderDto)
        {
            return new Order
            {
                OrderId = Guid.NewGuid(),
                CustomerId = addOrderDto.CustomerId,
                OrderStatus = false,
                PaymentStatus = false,
                TotalAmount= 0,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
