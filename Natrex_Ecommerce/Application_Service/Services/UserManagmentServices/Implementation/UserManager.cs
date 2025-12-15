using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.Services.UserManagmentServices.Interface;

namespace Application_Service.Services.UserManagmentServices.Implementation
{
    public class UserManager : IUserManager
    {
        public  Task<string> DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public  Task<List<GetUsersDto>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public  Task<string> UpdateUserAsync(UpdateUserDto request)
        {
            throw new NotImplementedException();
        }
    }
}
