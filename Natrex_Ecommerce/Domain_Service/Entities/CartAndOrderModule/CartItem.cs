using System.ComponentModel.DataAnnotations;
namespace Domain_Service.Entities.CartAndOrderModule
{
    /// <summary>
    /// Represents a single item inside a customer's cart.
    /// Each cart item references a product and tracks the quantity
    /// selected by the customer.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Primary key for the CartItem table.
        /// Uniquely identifies each cart item.
        /// </summary>
        [Key]
        public Guid CartItemId { get; set; }

        /// <summary>
        /// References the cart this item belongs to.
        /// Foreign key to the Cart table.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// References the product added to the cart.
        /// Foreign key to the Product table.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The quantity of the product selected by the customer.
        /// Must be >= 1.
        /// </summary>
        public int Quantity { get; set; } = 1;
    }
}