using Domain_Service.Entities.SellerModule;
using Domain_Service.RepoInterfaces.SellerAndShopDetails;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.SellerAndShopDetails
{
    public class SellerRepository : ISellerRepository
    {
        private readonly ApplicationDbContext _applicationDb;
        public SellerRepository(ApplicationDbContext dbContext)
        {
            _applicationDb = dbContext;
        }

        public Task<Seller> GetAllSellers()
        {
            throw new NotImplementedException();
        }
    }
}
