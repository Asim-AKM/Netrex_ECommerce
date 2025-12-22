using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.Cart_OrderDtos.OrderDtos
{
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
