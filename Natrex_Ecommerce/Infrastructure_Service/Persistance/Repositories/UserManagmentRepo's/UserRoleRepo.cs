using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.UserRoles
{
    public class UserRoleRepo : IUserRoleRepo
    {
        private readonly ApplicationDbContext _context;
        public UserRoleRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddUserRole(UserRole role)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRole> GetRolebyFK(Guid userId)
        {
            return await _context.UserRoles
               .Where(ur => ur.UserId == userId).FirstOrDefaultAsync() ?? new UserRole();
        }

        public async Task<List<RoleType>> GetUserRoles(Guid userId)
        {
            return _context.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleName).ToList();
        }
    }
}
