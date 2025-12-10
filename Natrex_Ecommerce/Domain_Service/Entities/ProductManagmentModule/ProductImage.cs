using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.ProductAndCategoryModule
{
    /// <summary>
    /// Represents an image associated with a product.
    /// This entity is used to store product image data including
    /// primary image identification and timestamps.
    /// </summary>
    public class ProductImage
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product image.
        /// This value serves as the primary key.
        /// </summary>
        [Key]
        public Guid ImageId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product
        /// to which this image belongs.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the URL of the product image.
        /// This is used to load and display the image in the application.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this image
        /// is the primary (main) image of the product.
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the image was uploaded.
        /// </summary>
        public DateTime UploadedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the image was last updated.
        /// </summary>
        public DateTime LastUpdatedAt { get; set; }
    }
}
