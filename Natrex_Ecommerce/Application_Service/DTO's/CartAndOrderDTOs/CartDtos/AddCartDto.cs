using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartAndOrderDTOs.CartDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used to create a new Cart for a specific customer.
    /// </summary>
    /// <remarks>
    /// This DTO is part of the Application layer in a Clean Architecture design. 
    /// It represents the data required from the client when creating a new Cart. 
    /// System-generated fields such as CartId and CreatedAt are not included,
    /// as they are generated internally by the application.
    /// </remarks>
    public record AddCartDto
    (
        /// <summary>
        /// The unique identifier of the customer for whom the cart is being created.
        /// This field is required.
        /// </summary>
        Guid CustomerId
    );

}
