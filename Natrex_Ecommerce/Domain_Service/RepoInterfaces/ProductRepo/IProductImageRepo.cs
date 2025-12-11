using Domain_Service.Entities.ProductAndCategoryModule;

namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductImageRepo
    {
        Task<ProductImage> GetByProductId(Guid productId);

    }
}
