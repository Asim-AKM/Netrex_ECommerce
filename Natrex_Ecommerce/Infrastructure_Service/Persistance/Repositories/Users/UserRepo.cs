using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.Users;

namespace Infrastructure_Service.Persistance.Repositories.Users
{
    internal class UserRepo : IUserRepo
    {
        public Task UserRegistration(User user)
        {
            throw new NotImplementedException();
        }
    }
}
