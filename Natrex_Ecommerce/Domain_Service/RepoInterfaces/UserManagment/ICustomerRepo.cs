using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.UserManagment
{
    public interface ICustomerRepo : IRepository<Customer>
    {
        Task<Customer> GetCustomerbyFK(Guid userId);
    }
}
