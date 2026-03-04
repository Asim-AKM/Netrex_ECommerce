using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.ProductRepo;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.ProductManagement
{
    public class ProductRankingRepo : Repository<Product>, IProductRankingRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductRankingRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetBestSellersAsync()
        {
            return await _context.Products
            .OrderByDescending(p => p.TotalSold)
            .Take(20)
            .ToListAsync();
        }

        public async Task<List<Product>> GetHomepageProductsAsync(
    Guid? categoryid = null,
    int pageNumber = 1,
    int pageSize = 10)
        {
            var query = _context.Products.AsQueryable();

            if (categoryid != null && categoryid != Guid.Empty)
            {
                query = query.Where(p => p.ProductCategoryId == categoryid);
            }

            var products = await query
                .Select(p => new
                {
                    Product = p,
                    Score = (p.TotalSold * 0.4m) +
                            (p.TotalViews * 0.2m) +
                            ((p.AverageRating * p.TotalReviews) * 0.4m)
                })
                .OrderByDescending(x => x.Score)
                .Skip((pageNumber - 1) * pageSize)   // 🔥 important
                .Take(pageSize)
                .Select(x => x.Product)
                .ToListAsync();

            return products;
        }
        public async Task<List<Product>> GetNewArrivalsAsync()
        {
            return await _context.Products
           .OrderByDescending(p => p.CreatedAt)
           .Take(20)
           .ToListAsync();
        }

        public async Task<List<Product>> GetTopRatedAsync()
        {
            return await _context.Products
            .OrderByDescending(p => p.AverageRating)
            .Take(20)
            .ToListAsync();
        }

        public async Task<List<Product>> GetTrendingAsync()
        {
            return await _context.Products
           .OrderByDescending(p => p.TotalViews)
           .Take(20)
           .ToListAsync();
        }
    }
}
