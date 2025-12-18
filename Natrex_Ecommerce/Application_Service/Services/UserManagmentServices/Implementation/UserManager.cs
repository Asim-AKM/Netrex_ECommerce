using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.Services.UserManagmentServices.Interface;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _uOW;
        public UserManager(IUnitOfWork uOW)
        {
            _uOW = uOW;
        }
        public async Task<string> DeleteUserAsync(Guid id)
        {
            var user = await _uOW.Users.GetById(id);
            if (user == null)
                return "Data Not Found";

            var cred = await _uOW.UserCreads.FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (cred != null)
                await _uOW.UserCreads.Delete(cred.CreadId); 

            var role = await _uOW.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.UserId);

            if (role != null)
                await _uOW.UserRoles.Delete(role.UserRoleId); 

            await _uOW.Users.Delete(user.UserId); 

            await _uOW.SaveChangesAsync();
            return "Data Deleted Successfully";

        }

        public async Task<List<GetUsersDto>> GetAllUserAsync()
        {
            var user = await _uOW.Users.GetAll();
            var role = await _uOW.UserRoles.GetAll();
            var data = (from u in user
                        join r in role
                        on u.UserId equals r.UserId
                        select new GetUsersDto
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

        public Task<string> UpdateUserAsync(UpdateUserDto request)
        {
            throw new NotImplementedException();
        }
    }
}
