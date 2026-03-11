namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductRepo : IRepository<Product>
    {
        Task<List<City>> GetCitiesByProvinceId(Guid Id);

        IQueryable<Product> QueryProducts();
        Task <List<Product>> GetAllProducts(Guid SellerId);

    }
}
