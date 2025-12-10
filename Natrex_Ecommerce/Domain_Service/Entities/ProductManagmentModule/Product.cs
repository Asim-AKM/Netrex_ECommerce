using System;
using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.ProductAndCategoryModule
{
    /// <summary>
    /// Represents a product entity in the system.
    /// This class stores all core details related to a product including
    /// pricing, stock, seller, and category information.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// This is the primary key of the Product table.
        /// </summary>
        [Key]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the seller
        /// who owns or listed this product.
        /// </summary>
        public Guid SellerId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product category
        /// to which this product belongs.
        /// </summary>
        public Guid ProductCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// This is the main display name shown to customers.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the detailed description of the product.
        /// This is used to explain product features and specifications.
        /// </summary>
        public string ProductDescription { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the original price of the product.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the product.
        /// This can be a flat amount or percentage based on business rules.
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        /// Gets or sets the available stock quantity of the product.
        /// This is used to manage inventory.
        /// </summary>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the product was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
