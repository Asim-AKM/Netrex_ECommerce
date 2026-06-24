using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.CartAndOrderDTOs.OrderDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used to create a new Order for a specific customer.
    /// </summary>
    /// <remarks>
    
    /// It represents the data required from the client when creating a new Order. 
    /// System-generated fields such as OrderId, CreatedAt, OrderStatus, and PaymentStatus 
    /// are not included, as they are generated internally by the system.
    /// </remarks>
    public record AddOrderDto
    (
        /// <summary>
        /// The unique identifier of the Customer placing the order.
        /// This field is required.
        /// </summary>
        Guid CustomerId,

        /// <summary>
        /// The total amount of the order.
        /// This field is required and must be greater than zero.
        /// </summary>
        double TotalAmount
    );

}
