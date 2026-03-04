using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductCategories : IRepository<ProductCategory>
    {
        Task<ProductCategory> GetByName(string name);
    }
}
