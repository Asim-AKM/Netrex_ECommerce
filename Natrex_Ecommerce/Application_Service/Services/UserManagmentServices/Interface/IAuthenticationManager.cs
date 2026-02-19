using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.DTO_s.UsersDto.Accounts;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IAuthenticationManager
    {
        Task<ApiResponse<CreateUserDto>> CreateUserAsync(CreateUserDto request);
        Task<ApiResponse<string>> VerifyRegistrationOtpAsync(VerifyRegistrationOtpDto request);
        Task<ApiResponse<object>> ResendRegistrationOtpAsync(string email);
        Task<ApiResponse<object>> LoginAsync(LoginDto request);
        Task<ApiResponse<object>> ForgetPasswordAsync(string userIdentifier);
        Task<ApiResponse<string>> ConfirmOtp(CheckOtpDto request);
        Task<ApiResponse<object>> LogoutAsync(string refreshToken);
    }
}
