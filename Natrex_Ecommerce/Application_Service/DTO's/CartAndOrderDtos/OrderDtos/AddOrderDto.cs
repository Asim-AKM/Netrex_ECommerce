namespace Application_Service.DTO_s.CartAndOrderDtos.OrderDtos
{
    public record AddOrderDto
     (
        /// <summary>
        /// The unique identifier of the Customer placing the order.
        /// This field is required.
        /// </summary>
        Guid CustomerId
    );
}
