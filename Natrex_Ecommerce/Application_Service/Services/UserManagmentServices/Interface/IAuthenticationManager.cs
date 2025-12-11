using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.DTO_s.UsersDto.Accounts;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IAuthenticationManager
    {
        Task<ApiResponse<CreateUserDto>> CreateUserAsync(CreateUserDto request);
        Task<ApiResponse<string>> LoginAsync(LoginDto request);
        Task<ApiResponse<string>> ForgetPasswordAsync(string userIdentifier);
    }
}
