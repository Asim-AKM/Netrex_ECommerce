using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.Cart_OrderDtos.OrderItemDtos
{
    public record GetOrderItemDto
     (
        /// <summary>
        /// The unique identifier of the OrderItem.
        /// System-generated and used to uniquely identify the item in the database.
        /// </summary>
        Guid OrderItemId,

        /// <summary>
        /// The unique identifier of the Order to which this item belongs.
        /// </summary>
        Guid OrderId,

        /// <summary>
        /// The unique identifier of the Product associated with this OrderItem.
        /// </summary>
        Guid ProductId,

        /// <summary>
        /// The quantity of the product in the order item.
        /// </summary>
        int Quantity,

        /// <summary>
        /// The unit price of the product in the order item.
        /// </summary>
        double Price,

        /// <summary>
        /// The total price for this order item (Quantity * Price).
        /// System-generated/calculated.
        /// </summary>
        double PriceTotal
    );
}
