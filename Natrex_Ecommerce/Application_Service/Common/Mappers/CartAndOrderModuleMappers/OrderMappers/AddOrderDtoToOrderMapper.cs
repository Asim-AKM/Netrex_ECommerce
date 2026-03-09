namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderMappers
{
    public static class AddOrderDtoToOrderMapper
    {
        public static Order Map(this Guid customerId,double totalAmount)
        {
            return new Order
            {
                OrderId = Guid.NewGuid(),
                CustomerId = customerId,
                OrderStatus = false,
                PaymentStatus = false,
                TotalAmount= totalAmount,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
