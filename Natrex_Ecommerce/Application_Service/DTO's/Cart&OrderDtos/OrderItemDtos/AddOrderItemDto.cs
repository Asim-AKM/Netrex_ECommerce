using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.Cart_OrderDtos.OrderItemDtos
{
     public record AddOrderItemDto
     (
        /// <summary>
        /// The unique identifier of the Order to which this item belongs.
        /// Required as a parent reference.
        /// </summary>
        Guid OrderId,

        /// <summary>
        /// The unique identifier of the Product to add to the order.
        /// Required to identify which product is being added.
        /// </summary>
        Guid ProductId,

        /// <summary>
        /// The quantity of the product to add.
        /// Must be greater than zero.
        /// </summary>
        int Quantity,

        /// <summary>
        /// The unit price of the product.
        /// Must be greater than zero.
        /// </summary>
        double Price
    );
}
