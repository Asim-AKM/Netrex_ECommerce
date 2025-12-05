using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.Users
{
    internal class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<User?> GetUserByIdentifier(string userIdentifier)
        {
            throw new NotImplementedException();
        }

    }
}
