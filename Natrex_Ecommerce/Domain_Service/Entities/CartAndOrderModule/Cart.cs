using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.CartAndOrderModule
{
    /// <summary>
    /// Represents the shopping cart of a customer.
    /// A cart contains multiple cart items and is used
    /// before converting the items into an order.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Primary key for the Cart table.
        /// Uniquely identifies each cart.
        /// </summary>
        [Key]
        public Guid CartId { get; set; }

        /// <summary>
        /// References the customer who owns this cart.
        /// This links the cart to a specific user/customer.
        /// </summary>
        public Guid CustomerId { get; set; }
    }
}
