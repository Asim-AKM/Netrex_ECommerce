using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductImageRepo : IRepository<ProductImage>
    {
        Task <List<ProductImage>> GetByProductId(Guid productId);
        Task<List<ProductImage>> GetAllProductImages();
        IQueryable<ProductImage> QueryProductImages();

    }
}
