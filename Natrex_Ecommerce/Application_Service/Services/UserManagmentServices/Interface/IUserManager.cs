using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.UserManagmentDto_s;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IUserManager
    {
        Task<ApiResponse<string>> UpdateUserAsync(UpdateUserDto request);
        Task<ApiResponse<string>> DeleteUserAsync(Guid id);
        Task<ApiResponse<List<GetUsersDto>>> GetAllUserAsync();
    }
}
