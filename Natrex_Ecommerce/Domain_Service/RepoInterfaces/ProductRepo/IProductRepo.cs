using Domain_Service.Entities.LocationModules;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductRepo : IRepository<Product>
    {
        Task<List<City>> GetCitiesByProvinceId(Guid Id);

        IQueryable<Product> QueryProducts();

    }
}
