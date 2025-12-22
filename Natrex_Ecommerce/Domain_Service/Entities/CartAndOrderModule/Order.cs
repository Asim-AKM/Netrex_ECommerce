using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.CartAndOrderModule
{
    /// <summary>
    /// Represents a customer order in the system.
    /// 
    /// An Order is created when a customer completes the checkout process.
    /// It stores overall order information such as status, payment state,
    /// total amount, and creation time.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Unique identifier for the order.
        /// This is the primary key used to uniquely identify an order.
        /// </summary>
        [Key]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Identifier of the customer who placed the order.
        /// This links the order to a specific customer.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Indicates the current status of the order.
        /// Example:
        /// false = Pending / Not Completed
        /// true  = Completed / Delivered
        /// </summary>
        public bool OrderStatus { get; set; }

        /// <summary>
        /// Indicates the payment status of the order.
        /// Example:
        /// false = Payment not completed
        /// true  = Payment completed
        /// </summary>
        public bool PaymentStatus { get; set; }

        /// <summary>
        /// Total payable amount for the order.
        /// This value is calculated from all associated OrderItems.
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// Date and time when the order was created.
        /// Useful for order history, tracking, and reporting.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
