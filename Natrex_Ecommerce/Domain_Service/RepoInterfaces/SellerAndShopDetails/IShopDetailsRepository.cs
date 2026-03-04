using Domain_Service.Entities.SellerModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain_Service.RepoInterfaces.SellerAndShopDetails
{
    /// <summary>
    /// Repository interface for accessing and managing <see cref="ShopDetail"/> entities in the database.
    /// </summary>
    public interface IShopDetailsRepository : IRepository<ShopDetail>
    {
        /// <summary>
        /// Retrieves all shop details from the database asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation, containing a <see cref="List{T}"/> of <see cref="ShopDetail"/> entities.
        /// </returns>
        Task<List<ShopDetail>> GetAllShopDetails();
    }
}
