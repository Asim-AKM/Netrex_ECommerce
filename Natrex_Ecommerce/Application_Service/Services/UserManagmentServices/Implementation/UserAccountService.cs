using Application_Service.Common.Mappers.UserCreadentialMappers;
using Application_Service.Common.Mappers.UserMapper;
using Application_Service.Common.Mappers.UserRoleMappers;
using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.Services.UserManagmentServices.Interface;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IPasswordEncriptor _passwordEcriptor;
        private readonly IUnitOfWork _uOW;
     
        public UserAccountService(IPasswordEncriptor passwordEcriptor , IUnitOfWork unitOfwork)
        {
            _passwordEcriptor = passwordEcriptor;
            _uOW = unitOfwork;


        }
        public Task<string> UserRegistrationAsync(UserRegisterDto request)
        {
            var UserdomainModel = request.Map();
            var UserRolDomainModel = UserdomainModel.AssingRole();
            var UserCredentialDomainModel = UserdomainModel.AssingToCreadential();
          
            _passwordEcriptor.CreateHashAndSalt(request.password,out byte[] salt,out byte[] hash);
                    UserCredentialDomainModel.PasswordSalt = salt;
                    UserCredentialDomainModel.PasswordHash = hash;

            _uOW.Users.Create(UserdomainModel);
            _uOW.UserRoles.Create(UserRolDomainModel);
            _uOW.UserCreads.Create(UserCredentialDomainModel);
            _uOW.SaveChangesAsync();

            return Task.FromResult(" User Has Been Registered ");
        }
    }
}
