using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartAndOrderDTOs.CartItemDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used to update an existing CartItem.
    /// </summary>
    /// <remarks>
    /// It represents the data that the client is allowed to update for a CartItem.
    /// The CartItemId identifies which item to update, and Quantity is the only mutable field.
    /// Other fields such as CartId or ProductId are immutable and cannot be updated.
    /// </remarks>
    public record UpdateCartItemDto
    (
        /// <summary>
        /// The unique identifier of the CartItem to update.
        /// This is a system-generated field used to identify the CartItem in the database.
        /// </summary>
        Guid CartItemId,

        /// <summary>
        /// The new quantity for the CartItem.
        /// Must be greater than zero.
        /// </summary>
        int Quantity
    );

}
