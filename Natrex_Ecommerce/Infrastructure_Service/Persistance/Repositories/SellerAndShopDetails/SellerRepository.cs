using Domain_Service.Entities.SellerModule;
using Domain_Service.RepoInterfaces.SellerAndShopDetails;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure_Service.Persistance.Repositories.SellerAndShopDetails
{
    /// <summary>
    /// Repository implementation for accessing and managing <see cref="Seller"/> entities in the database.
    /// </summary>
    public class SellerRepository : ISellerRepository
    {
        private readonly ApplicationDbContext _applicationDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="SellerRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The <see cref="ApplicationDbContext"/> instance for database access.</param>
        public SellerRepository(ApplicationDbContext dbContext)
        {
            _applicationDb = dbContext;
        }

        /// <summary>
        /// Retrieves all sellers from the database asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation, containing a <see cref="List{T}"/> of <see cref="Seller"/> entities.
        /// </returns>
        public async Task<List<Seller>> GetAllSellers()
        {
            return await _applicationDb.Sellers.ToListAsync();
        }
    }
}
