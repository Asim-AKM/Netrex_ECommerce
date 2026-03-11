namespace Infrastructure_Service.Persistance.Repositories.ProductManagement
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {

        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<List<Product>> GetAllProducts(Guid SellerId)
        {
          return await _context.Products.Where(x=> x.SellerId == SellerId).ToListAsync();
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
