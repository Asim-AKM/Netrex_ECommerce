using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.UserRoles
{
    public class UserRoleRepo : IUserRoleRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRoleRepo(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public  async Task<List<UserRole>> GetAllRoles()
        {
            return await _applicationDbContext.UserRoles.ToListAsync();
        }

        public async Task<UserRole> GetUserRoleByFK(Guid id)
        {
          var data=  await _applicationDbContext.UserRoles.Where(x=>x.UserId==id).FirstOrDefaultAsync()?? new UserRole();
            return data;
        }
    }
}
