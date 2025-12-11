using Application_Service.DTO_s.UserManagmentDto_s;
using Domain_Service.Entities.UserManagmentModule;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface ICustomermanager
    {
        Task<string> UpdateCustomer(UpdateCustomerDto updateCustomer);
        Task<string> DeleteCustomer(Guid customerId);
       // Task<Customer> GetById(Guid id);
       Task<Customer> GetAllCustomer(Guid customerId);

    }
}
