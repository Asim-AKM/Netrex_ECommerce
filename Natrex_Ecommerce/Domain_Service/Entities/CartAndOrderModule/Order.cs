using Domain_Service.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.CartAndOrderModule
{
    /// <summary>
    /// Represents a customer order. 
    /// Contains order status, payment status, total amount,
    /// and references to the customer who placed the order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Primary key for the Order table.
        /// Uniquely identifies each order.
        /// </summary>
        [Key]
        public Guid OrderId { get; set; }

        /// <summary>
        /// References the customer who placed this order.
        /// Foreign key to Customer table.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Current status of the order in the order lifecycle.
        /// Example: Pending, Processing, Shipped, Delivered, Cancelled.
        /// </summary>
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// Current payment status of the order.
        /// Example: Pending, Paid, Failed.
        /// </summary>
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// Total amount of the order (sum of all order items).
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// Date and time when the order was created.
        /// Useful for tracking order placement and analytics.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
