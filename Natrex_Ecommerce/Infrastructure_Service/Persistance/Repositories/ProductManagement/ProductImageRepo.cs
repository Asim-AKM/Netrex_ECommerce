using Domain_Service.RepoInterfaces.ProductRepo;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.ProductManagement
{
    public class ProductImageRepo : IProductImageRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductImageRepo(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;

        }

        
    }
}
