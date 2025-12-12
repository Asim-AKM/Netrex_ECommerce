using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.UserManagmentDto_s;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface ICustomerManager
    {
        Task<ApiResponse<string>> UpdateCustomer(UpdateCustomerDto updateCustomer);
        Task<ApiResponse<string>> DeleteCustomer(Guid customerId);
        // Task<Customer> GetById(Guid id);
        Task<ApiResponse<List<GetCustomerDto>>> GetAllCustomers();

    }
}
