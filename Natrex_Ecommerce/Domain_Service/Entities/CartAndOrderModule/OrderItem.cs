using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.CartAndOrderModule
{
    /// <summary>
    /// Represents an individual item within an order.
    /// 
    /// OrderItem stores product-level details for an order,
    /// including quantity, price at the time of purchase,
    /// and the total price for that product.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Unique identifier for the order item.
        /// This is the primary key used to uniquely identify
        /// each item within an order.
        /// </summary>
        [Key]
        public Guid OrderItemId { get; set; }

        /// <summary>
        /// Identifier of the order to which this item belongs.
        /// This creates a relationship between Order and OrderItem.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Identifier of the product included in the order.
        /// This links the order item to a specific product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantity of the product ordered.
        /// Represents how many units of the product
        /// were purchased in this order.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price of a single unit of the product at the time
        /// the order was placed.
        /// This value is fixed and does not change even if
        /// the product price changes later.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Total price for this order item.
        /// Calculated as:
        /// Quantity × Price
        /// </summary>
        public double PriceTotal { get; set; }
    }
}
