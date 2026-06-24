using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartAndOrderDTOs.CartItemDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used to return details of a CartItem to the client.
    /// </summary>
    /// <remarks>
    
    /// It represents the read-only data sent from the system to the client when retrieving a CartItem. 
    /// System-generated fields such as CartItemId are included because they are required to identify the item.
    /// </remarks>
    public record GetCartItemDto
    (
        /// <summary>
        /// The unique identifier of the CartItem.
        /// This field is system-generated and uniquely identifies the item in the database.
        /// </summary>
        Guid CartItemId,

        /// <summary>
        /// The unique identifier of the Cart to which this item belongs.
        /// </summary>
        Guid CartId,

        /// <summary>
        /// The unique identifier of the Product associated with this CartItem.
        /// </summary>
        Guid ProductId,

        /// <summary>
        /// The quantity of the product in the cart item.
        /// </summary>
        int Quantity
    );

}
