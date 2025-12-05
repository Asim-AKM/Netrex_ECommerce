using Application_Service.DTO_s.UserManagmentDto_s;
using Domain_Service.Entities.UserManagmentModule;

namespace Application_Service.Services.Interface
{
    public interface IUserAccountService
    {
        Task<string> CreateUserAsync(UserRegisterDto Request);
        Task<string> UpdateUserAsync(UpdateUserDto Request);
        Task<string> DeleteUserAsync(Guid Id);
        Task<List<User>> GetUsersAsync();

    }
}
