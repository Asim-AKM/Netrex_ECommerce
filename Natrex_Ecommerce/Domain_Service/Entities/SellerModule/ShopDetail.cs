using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Entities.SellerModule
{
    /// <summary>
    /// Represents details about a shop in the system.
    /// This entity stores the category or type of the shop.
    /// </summary>
    public class ShopDetail
    {
        /// <summary>
        /// Primary key for the ShopDetail entity.
        /// Uniquely identifies each shop.
        /// </summary>
        [Key]
        public Guid ShopId { get; set; }

        /// <summary>
        /// The category or type of the shop.
        /// Example: "Electronics", "Clothing", "Grocery".
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;
    }
}
