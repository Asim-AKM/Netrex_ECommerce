namespace Domain_Service.RepoInterfaces.ProductRepo
{
    public interface IProductCategories
    {
        Task<ProductCategory> GetByName(string name);
    }
}
