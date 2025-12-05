using Application_Service.DTO_s.UsersDto.Accounts;

namespace Application_Service.Services.UserManagmentServices.Interface
{
    public interface IUserAccountService
    {
        Task<string> UserRegistrationAsync(UserRegisterDto Request);
    }
}
