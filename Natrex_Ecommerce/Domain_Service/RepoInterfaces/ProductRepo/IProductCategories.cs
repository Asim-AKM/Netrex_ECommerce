namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductCategories : IRepository<ProductCategory>
    {
        Task<ProductCategory> GetByName(string name);
    }
}
