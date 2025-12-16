using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartAndOrderDTOs.OrderDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used to update an existing Order's status.
    /// </summary>
    /// <remarks>
    /// It represents the data that the client is allowed to update for an Order.
    /// The OrderId identifies which order to update, and OrderStatus and PaymentStatus are the only mutable fields.
    /// Other fields such as CustomerId, TotalAmount, and CreatedAt are immutable and cannot be updated.
    /// </remarks>
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
