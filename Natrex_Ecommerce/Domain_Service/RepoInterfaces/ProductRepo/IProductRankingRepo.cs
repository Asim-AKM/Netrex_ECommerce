using Domain_Service.Entities.ProductAndCategoryModule;

namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductRankingRepo
    {
        Task<List<Product>> GetBestSellersAsync();
        Task<List<Product>> GetTrendingAsync();
        Task<List<Product>> GetTopRatedAsync();
        Task<List<Product>> GetHomepageProductsAsync();
        Task<List<Product>> GetNewArrivalsAsync();
    }
}
