using Domain_Service.RepoInterfaces.ProductRepo;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.ProductManagement
{
    public class ProductRepo : IProductRepo
    {

        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;

        }


        
    }
}
