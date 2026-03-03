using Domain_Service.Entities.ProductAndCategoryModule;

namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductCategories
    {
        Task<ProductCategory> GetByName(string name);
    }
}
