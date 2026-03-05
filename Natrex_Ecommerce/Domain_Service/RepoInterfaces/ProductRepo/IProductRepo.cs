namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductRepo
    {
        Task<List<City>> GetCitiesByProvinceId(Guid Id);

        IQueryable<Product> QueryProducts();

    }
}
