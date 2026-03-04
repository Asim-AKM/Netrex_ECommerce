using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductRankingRepo : IRepository<Product>
    {
        Task<List<Product>> GetBestSellersAsync();
        Task<List<Product>> GetTrendingAsync();
        Task<List<Product>> GetTopRatedAsync();
        Task<List<Product>> GetHomepageProductsAsync(Guid? categoryid = null, int pageNumber = 1, int pageSize = 10);
        Task<List<Product>> GetNewArrivalsAsync();
    }
}
