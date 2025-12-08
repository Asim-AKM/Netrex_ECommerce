using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.UserCreadentials
{
    public class UserCreadentialRepo : IUserCreadentialRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserCreadentialRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<UserCreadential> GetUserCredentialByFK(Guid id)
        {
            return await _applicationDbContext.UsersCreads.Where(x => x.UserId == id).FirstOrDefaultAsync() ?? new UserCreadential();
        }
    }
}
