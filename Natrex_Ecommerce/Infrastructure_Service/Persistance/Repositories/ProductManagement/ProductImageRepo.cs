using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.ProductRepo;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.ProductManagement
{
    public class ProductImageRepo : IProductImageRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductImageRepo(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;

        }

        public async Task<ProductImage> GetByProductId(Guid productId)
        {
            var productImage = await _context.ProductImages.Where(pi => pi.ProductId == productId).FirstOrDefaultAsync();
            return productImage!;
        }
    }
}
