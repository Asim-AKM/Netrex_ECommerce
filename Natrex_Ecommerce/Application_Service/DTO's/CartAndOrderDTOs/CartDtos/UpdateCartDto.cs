using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartAndOrderDTOs.CartDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used to update an existing Cart's information.
    /// </summary>
    /// <remarks>
    /// It represents the data that the client is allowed to update for a Cart.
    /// The CartId is system-generated and identifies the cart to update, 
    /// while the CustomerId may be updated depending on business rules.
    /// </remarks>
    public record UpdateCartDto
    (
        /// <summary>
        /// The unique identifier of the Cart to update.
        /// This field is system-generated and required to identify the cart in the system.
        /// </summary>
        Guid CartId,

        /// <summary>
        /// The unique identifier of the Customer associated with the cart.
        /// This field may be updated depending on business rules.
        /// </summary>
        Guid CustomerId
    );

}
