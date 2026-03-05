namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface ICustomerRepo : IRepository<Customer>
    {
        Task<Customer> GetCustomerbyFK(Guid userId);
    }
}
