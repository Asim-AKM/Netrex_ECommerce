using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.SellerModule
{
    /// <summary>
    /// Represents a seller in the system.
    /// Each seller is linked to a user account and a shop.
    /// This entity stores basic information such as store name,
    /// description, and address.
    /// </summary>
    public class Seller
    {
        /// <summary>
        /// Primary key for the Seller entity.
        /// Uniquely identifies each seller.
        /// </summary>
        [Key]
        public Guid SellerId { get; set; }
        /// <summary>
        /// The ID of the user account associated with this seller.
        /// Every seller must have a valid user account.
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// The ID of the shop linked to this seller.
        /// Connects to the ShopDetail entity.
        /// </summary>
        public Guid ShopId { get; set; }
        /// <summary>
        /// The official name of the seller's store.
        /// Example: "Tech World".
        /// </summary>
        public string StoreName { get; set; } = string.Empty;
        /// <summary>
        /// A short description of the store.
        /// Example: "We sell electronics and accessories."
        /// </summary>
        public string StoreDescription { get; set; } = string.Empty;
        /// <summary>
        /// The physical address of the store.
        /// Example: "123 Main Street, Lahore".
        /// </summary>
        public string Address { get; set; } = string.Empty;
    }
}
