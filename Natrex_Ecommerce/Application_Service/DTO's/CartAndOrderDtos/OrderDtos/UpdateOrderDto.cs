namespace Application_Service.DTO_s.CartAndOrderDtos.OrderDtos
{
    public record UpdateOrderDto
        (
        /// <summary>
        /// The unique identifier of the Order to update.
        /// This is a system-generated field used to identify the Order in the database.
        /// </summary>
        Guid OrderId,

        /// <summary>
        /// The new status of the order.
        /// True if the order is processed/completed; otherwise, false.
        /// </summary>
        bool OrderStatus,

        /// <summary>
        /// The new payment status of the order.
        /// True if payment has been completed; otherwise, false.
        /// </summary>
        bool PaymentStatus
    );
}
