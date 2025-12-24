using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.Users
{
    internal class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdentifier(string userIdentifier)
        {
            return await _context.Users.Where(x => x.Email == userIdentifier || x.Contact == userIdentifier || x.UserName == userIdentifier).FirstOrDefaultAsync();
        }

    }
}
