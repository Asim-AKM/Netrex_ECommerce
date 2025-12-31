namespace Application_Service.DTO_s.CartAndOrderDtos.OrderDtos
{
    public record GetOrderDto
     (
        /// <summary>
        /// The unique identifier of the Order.
        /// System-generated and used to uniquely identify the order in the system.
        /// </summary>
        Guid OrderId,

        /// <summary>
        /// The unique identifier of the Customer who placed the order.
        /// </summary>
        Guid CustomerId,

        /// <summary>
        /// The current status of the order.
        /// True if the order has been processed/completed; otherwise, false.
        /// </summary>
        bool OrderStatus,

        /// <summary>
        /// The payment status of the order.
        /// True if payment has been completed; otherwise, false.
        /// </summary>
        bool PaymentStatus,

        /// <summary>
        /// The total amount of the order.
        /// </summary>
        double TotalAmount,

        /// <summary>
        /// The date and time when the order was created.
        /// System-generated and useful for auditing and tracking.
        /// </summary>
        DateTime CreatedAt
    );

}
