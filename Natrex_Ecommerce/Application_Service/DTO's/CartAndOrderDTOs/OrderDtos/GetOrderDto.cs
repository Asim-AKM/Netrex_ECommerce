using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartAndOrderDTOs.OrderDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used to return details of an Order to the client.
    /// </summary>
    /// <remarks>
    /// This DTO is part of the Application layer in a Clean Architecture design. 
    /// It represents the read-only data sent from the system to the client when retrieving an Order. 
    /// System-generated fields such as OrderId and CreatedAt are included because they are required for identification and auditing purposes.
    /// </remarks>
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
