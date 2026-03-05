namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IUserManager
    {
        Task<ApiResponse<string>> UpdateUserAsync(UpdateUserDto request);
        Task<ApiResponse<string>> DeleteUserAsync(Guid id);
        Task<ApiResponse<List<GetUsersDto>>> GetAllUserAsync();
        Task<ApiResponse<string>> UpdateUserStatusAsync(UpdateUserStatusDto request);
    }
}
