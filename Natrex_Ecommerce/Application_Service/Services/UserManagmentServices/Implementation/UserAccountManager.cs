using Application_Service.Common.Mappers.UserCreadentialMappers;
using Application_Service.Common.Mappers.UserMapper;
using Application_Service.Common.Mappers.UserRoleMappers;
using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.Services.UserManagmentServices.Interface;
using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class UserAccountManager : IUserAccountManger
    {
        private readonly IPasswordEncriptor _passwordEcriptor;
        private readonly IUnitOfWork _uOW;

        public UserAccountManager(IPasswordEncriptor passwordEcriptor, IUnitOfWork unitOfwork)
        {
            _passwordEcriptor = passwordEcriptor;
            _uOW = unitOfwork;
        }
        public async Task<string> DeleteUserAsync(Guid id)
        {
            var data = await GetUserbyId(id);
            if (data != null)
            {
                await _uOW.Users.Delete(data);
                var role = await _uOW.UserRoleRepo.GetUserRoleByFK(data.UserId);
                await _uOW.UserRoles.Delete(role);
                var carendential = await _uOW.UserCreadRepo.GetUserCredentialByFK(data.UserId);
                await _uOW.UserCreads.Delete(carendential);
                await _uOW.SaveChangesAsync();
                return "Data Deleted Successfully";
            }
            return "Data is NotFound";
        }

        public async Task<List<GetUserDto>> GetAllUserAsync()
        {
            var user = await _uOW.UserRepo.GetAllUser();
            var role = await _uOW.UserRoleRepo.GetAllRoles();
            var data = (from u in user
                        join r in role
                        on u.UserId equals r.UserId
                        select new GetUserDto
                        {
                            FullName = u.FullName,
                            Contact = u.Contact,
                            CreateAt = u.CreateAt,
                            Email = u.Email,
                            ImageUrl = u.ImageUrl,
                            RoleName = r.RoleName,
                            Username = u.UserName,
                            Userstatus = u.Status,
                        }).ToList();
            return data;
        }
        public async Task<User?> GetUserbyId(Guid id)
        {
            return await _uOW.Users.GetById(id);
        }

        public async Task<string> UpdateUserAsync(UpdateUserDto request)
        {
            var data = await GetUserbyId(request.Id);
            if (data != null)
            {
                data.FullName = request.FullName;
                data.ImageUrl = request.ImageUrl;
                data.UserName = request.UserName;
                data.Email = request.Email;
                data.Contact = request.Contact;
                data.Status = data.Status;
                data.UpdatedAt = DateTime.UtcNow;

                await _uOW.Users.Update(data);
                await _uOW.SaveChangesAsync();
            }
            return "Data is NotFound";
        }

        public async Task<string> CreateUserAsync(UserRegisterDto request)
        {
            var data = _uOW.UserRepo.CheckEmail(request.email);
            if (data != null)
            {
                var UserdomainModel = request.Map();
                var UserRolDomainModel = UserdomainModel.AssingRole();
                var UserCredentialDomainModel = UserdomainModel.AssingToCreadential();
                await _passwordEcriptor.CreateHashAndSalt(request.password, out byte[] salt, out byte[] hash);
                UserCredentialDomainModel.PasswordSalt = salt;
                UserCredentialDomainModel.PasswordHash = hash;
                await _uOW.Users.Create(UserdomainModel);
                await _uOW.UserRoles.Create(UserRolDomainModel);
                await _uOW.UserCreads.Create(UserCredentialDomainModel);
                await _uOW.SaveChangesAsync();
                return " User Has Been Registered ";
            }
            return "Credential already Present";
        }
    }
}
