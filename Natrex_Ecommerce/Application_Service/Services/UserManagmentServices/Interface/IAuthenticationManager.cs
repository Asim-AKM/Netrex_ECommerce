using Application_Service.DTO_s.UserManagmentDto_s;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IAuthenticationManager
    {
        Task<string> LoginAsync(LoginDto request);
    }
}
