using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.ProductAndCategoryModule
{
    /// <summary>
    /// Represents a product category used to classify products
    /// within the system.
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product category.
        /// This value serves as the primary key.
        /// </summary>
        [Key]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the display name of the product category.
        /// This name is used for categorizing and filtering products.
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;
    }
}
