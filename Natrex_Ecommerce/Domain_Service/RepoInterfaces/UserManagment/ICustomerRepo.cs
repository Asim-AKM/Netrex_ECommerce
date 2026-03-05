namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface ICustomerRepo 
    {
        Task<Customer> GetCustomerbyFK(Guid userId);
    }
}
