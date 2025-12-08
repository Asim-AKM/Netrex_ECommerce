using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.UserCreadentials
{
    public class UserCreadentialRepo : IUserCreadentialRepo
    {
        private readonly ApplicationDbContext _context;
        public UserCreadentialRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddUserCreadential(UserCreadential userCreadential)
        {
            throw new NotImplementedException();
        }
    }
}
