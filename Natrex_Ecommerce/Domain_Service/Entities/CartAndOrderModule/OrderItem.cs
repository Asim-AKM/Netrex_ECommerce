using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.CartAndOrderModule
{
    /// <summary>
    /// Represents an individual item within an order.
    /// Each order item references a product and tracks the quantity,
    /// individual price, and total price for that item.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// Primary key for the OrderItem table.
        /// Uniquely identifies each order item.
        /// </summary>
        [Key]
        public Guid OrderItemId { get; set; }

        /// <summary>
        /// References the order this item belongs to.
        /// Foreign key to the Order table.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// References the product included in the order.
        /// Foreign key to the Product table.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Number of units of the product included in the order.
        /// Must be >= 1.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Price of a single unit of the product at the time of ordering.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Total price for this order item (Quantity × Price).
        /// </summary>
        public decimal PriceTotal { get; set; }
    }
}
