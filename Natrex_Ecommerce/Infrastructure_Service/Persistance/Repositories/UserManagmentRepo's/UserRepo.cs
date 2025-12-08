using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.Users
{
    internal class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async  Task<User?> CheckEmail(string email)
        {
            return  await _applicationDbContext.Users.Where(x=>x.Email == email || x.UserName==email).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUser()
        {
           return await _applicationDbContext.Users.ToListAsync();
        }
    }
}
