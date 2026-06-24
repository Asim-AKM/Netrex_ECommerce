using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartAndOrderDTOs.CartItemDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used to add a new item to an existing Cart.
    /// </summary>
    /// <remarks>
    
    /// It represents the data required from the client when adding a new CartItem. 
    /// System-generated fields such as CartItemId are not included, as they are generated internally.
    /// </remarks>
    public record AddCartItemDto
    (
        /// <summary>
        /// The unique identifier of the Cart to which this item will be added.
        /// This is a required parent reference.
        /// </summary>
        Guid CartId,

        /// <summary>
        /// The unique identifier of the Product to add to the cart.
        /// This is required to identify the product being added.
        /// </summary>
        Guid ProductId,

        /// <summary>
        /// The quantity of the product to add to the cart.
        /// Must be greater than zero.
        /// </summary>
        int Quantity
    );

}
