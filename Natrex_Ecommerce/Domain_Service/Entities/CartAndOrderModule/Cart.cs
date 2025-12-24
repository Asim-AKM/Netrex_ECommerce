using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain_Service.Entities.CartAndOrderModule
{
    /// <summary>
    /// Represents a shopping cart for a customer.
    /// 
    /// The Cart entity is used to temporarily store products that a customer
    /// intends to purchase. Each customer can have only one active cart at a time.
    /// The cart acts as a container for CartItem entities.
    /// </summary>
    /// 
    
    public class Cart
    {
      
        /// <summary>
        /// Unique identifier for the cart.
        /// This is the primary key used to uniquely identify a cart record.
        /// </summary>
        [Key]
        public Guid CartId { get; set; }

        /// <summary>
        /// Identifier of the customer who owns this cart.
        /// This creates a logical relationship between Customer and Cart.
        /// </summary>
        public Guid CustomerId { get; set; }
    }
}
