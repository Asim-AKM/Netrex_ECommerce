using Application_Service.Common.Mappers.UserCreadentialMappers;
using Application_Service.Common.Mappers.UserMapper;
using Application_Service.Common.Mappers.UserRoleMappers;
using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.Services.Interface;
using Domain_Service.Entities.Users;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Application_Service.Services.Implementation
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IPasswordEncriptor _passwordEcriptor;
        private readonly IRepository<User> _repository;
     
        public UserAccountService(IPasswordEncriptor passwordEcriptor , IRepository<User> repository)
        {
            _passwordEcriptor = passwordEcriptor;
            _repository = repository;

        }
        public Task<string> UserRegistrationAsync(UserRegisterDto request)
        {
            var UserdomainModel = request.Map();
            var UserRolDomainModel = UserdomainModel.AssingRole();
            var UserCredentialDomainModel = UserdomainModel.AssingToCreadential();
            _passwordEcriptor.CreateHashAndSalt(request.password,out byte[] salt,out byte[] hash);
            UserCredentialDomainModel.PasswordSalt = salt;
            UserCredentialDomainModel.PasswordHash = hash;

            return Task.FromResult(" User Registered Sexyfully");
        }
    }
}
