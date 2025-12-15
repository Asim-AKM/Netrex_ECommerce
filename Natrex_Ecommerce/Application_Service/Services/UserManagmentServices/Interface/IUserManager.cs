using Application_Service.DTO_s.UserManagmentDto_s;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IUserManager
    {
        Task<string> UpdateUserAsync(UpdateUserDto request);
        Task<string> DeleteUserAsync(Guid id);
        Task<List<GetUsersDto>> GetAllUserAsync();
    }
}
