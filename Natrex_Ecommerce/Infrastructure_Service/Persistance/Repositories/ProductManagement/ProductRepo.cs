using Domain_Service.Entities.LocationModules;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.ProductRepo;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.ProductManagement
{
    public class ProductRepo :  Repository<Product>,IProductRepo
    {

        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<List<City>> GetCitiesByProvinceId(Guid Id)
        {
            return await _context.Cities.Where(x => x.ProvinceId == Id).ToListAsync();
        }
      
        public IQueryable<Product> QueryProducts()
        {
            return _context.Products.AsQueryable();
        }
    }
}
