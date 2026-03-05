namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface ICustomerManager
    {
        Task<ApiResponse<string>> UpdateCustomer(UpdateCustomerDto updateCustomer);
        Task<ApiResponse<string>> DeleteCustomer(Guid customerId);
        // Task<Customer> GetById(Guid id);
        Task<ApiResponse<List<GetCustomerDto>>> GetAllCustomers();
        Task<ApiResponse<string>> UpdateProfileImage(Guid userId, IFormFile file);

    }
}
