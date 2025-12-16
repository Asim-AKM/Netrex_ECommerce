using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartAndOrderDTOs.OrderItemDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used to update an existing OrderItem.
    /// </summary>
    /// <remarks>
    /// It represents the data that the client is allowed to update for an OrderItem.
    /// The OrderItemId identifies which item to update, and Quantity and Price are the only mutable fields.
    /// Other fields such as OrderId and ProductId are immutable and cannot be updated.
    /// </remarks>
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
