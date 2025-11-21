using Application_Service.Common.Mappers.UserCreadentialMappers;
using Application_Service.Common.Mappers.UserMapper;
using Application_Service.Common.Mappers.UserRoleMappers;
using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.Implementation
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IPasswordEncriptor _passwordEcriptor;
        public UserAccountService(IPasswordEncriptor passwordEcriptor)
        {
            _passwordEcriptor = passwordEcriptor;
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
