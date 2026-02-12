using Domain_Service.Entities.LocationModules;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductRepo
    {
        Task<List<City>> GetCitiesByProvinceId(Guid Id);
        //Task<List<Product>> GetAllProducts();

    }
}
