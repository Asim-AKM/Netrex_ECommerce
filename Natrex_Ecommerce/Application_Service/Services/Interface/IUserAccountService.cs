using Application_Service.DTO_s.UsersDto.Accounts;

namespace Application_Service.Services.Interface
{
    public interface IUserAccountService
    {
        Task<string> UserRegistrationAsync(UserRegisterDto Request);
    }
}
