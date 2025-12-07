using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.DTO_s.UsersDto.Accounts;
using Domain_Service.Entities.UserManagmentModule;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IUserAccountManger
    {
        Task<string> CreateUserAsync(UserRegisterDto request);
        Task<string> UpdateUserAsync(UpdateUserDto request);
        Task<string> DeleteUserAsync(Guid id);
        Task<List<GetUserDto>> GetAllUserAsync();
        Task<User?> GetUserbyId(Guid id);

    }
}
