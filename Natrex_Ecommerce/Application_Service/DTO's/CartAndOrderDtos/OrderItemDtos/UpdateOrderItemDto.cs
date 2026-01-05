namespace Application_Service.DTO_s.CartAndOrderDtos.OrderItemDtos
{
    public record UpdateOrderItemDto
     (
        /// <summary>
        /// The unique identifier of the OrderItem to update.
        /// This is a system-generated field used to identify the OrderItem in the database.
        /// </summary>
        Guid OrderItemId,

        /// <summary>
        /// The new quantity for the OrderItem.
        /// Must be greater than zero.
        /// </summary>
        int Quantity,

        /// <summary>
        /// The new unit price for the OrderItem.
        /// Must be greater than zero.
        /// </summary>
        double Price
    );

}