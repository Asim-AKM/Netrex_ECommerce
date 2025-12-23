using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.CartAndOrderModule
{
    /// <summary>
    /// Represents an individual product item inside a shopping cart.
    /// 
    /// CartItem acts as a bridge between Cart and Product.
    /// It stores which product is added to the cart and in what quantity.
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Unique identifier for the cart item.
        /// This is the primary key used to uniquely identify a cart item record.
        /// </summary>
        [Key]
        public Guid CartItemId { get; set; }

        /// <summary>
        /// Identifier of the cart to which this item belongs.
        /// This establishes a relationship between Cart and CartItem.
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Identifier of the product added to the cart.
        /// This links the cart item to a specific product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Quantity of the product added to the cart.
        /// This value determines how many units of the product
        /// the customer intends to purchase.
        /// </summary>
        public int Quantity { get; set; }
    }
}
