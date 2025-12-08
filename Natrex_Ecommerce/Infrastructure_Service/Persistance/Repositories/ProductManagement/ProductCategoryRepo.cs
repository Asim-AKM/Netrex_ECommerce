using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.ProductRepo;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.ProductManagement
{
    public class ProductCategoryRepo : IProductCategories
    {
        private readonly ApplicationDbContext _context;
        public ProductCategoryRepo(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<ProductCategory> GetByName(string name)
        {
            var data = await _context.ProductCategories.FirstOrDefaultAsync(c => c.CategoryName == name);
            return data!;
        }
    }
}
