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

        public async Task<List<ProductImage>> GetByProductId(Guid productId)
        {
            return await _context.ProductImages.Where(pi => pi.ProductId == productId).ToListAsync();
        }

        public async Task<List<ProductImage>> GetAllProductImages()
        {
            return await _context.ProductImages.ToListAsync();
        }
       
        public IQueryable<ProductImage> QueryProductImages()
        {
            return _context.ProductImages.AsQueryable();
        }
    }
}
