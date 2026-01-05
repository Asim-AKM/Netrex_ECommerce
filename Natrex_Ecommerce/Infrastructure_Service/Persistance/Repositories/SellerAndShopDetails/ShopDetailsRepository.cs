using Domain_Service.Entities.SellerModule;
using Domain_Service.RepoInterfaces.SellerAndShopDetails;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure_Service.Persistance.Repositories.SellerAndShopDetails
{
    /// <summary>
    /// Repository implementation for accessing and managing <see cref="ShopDetail"/> entities in the database.
    /// </summary>
    public class ShopDetailsRepository : IShopDetailsRepository
    {
        private readonly ApplicationDbContext _applicationDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopDetailsRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The <see cref="ApplicationDbContext"/> instance for database access.</param>
        public ShopDetailsRepository(ApplicationDbContext dbContext)
        {
            _applicationDb = dbContext;
        }

        /// <summary>
        /// Retrieves all shop details from the database asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation, containing a <see cref="List{T}"/> of <see cref="ShopDetail"/> entities.
        /// </returns>
        public async Task<List<ShopDetail>> GetAllShopDetails()
        {
            return await _applicationDb.ShopDetails.ToListAsync();
        }
    }
}
