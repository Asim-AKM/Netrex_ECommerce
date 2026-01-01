using Domain_Service.Entities.UserManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.UserCreadentials
{
    public class UserCreadentialRepo : IUserCreadentialRepo
    {
        private readonly ApplicationDbContext _context;
        public UserCreadentialRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserCreadential> GetCreadbyFK(Guid userId)
        {
            return await _context.UserCreadentials.AsNoTracking().Where(ur => ur.UserId == userId).FirstOrDefaultAsync() ?? new UserCreadential();
        }

        public async Task<int> UpdateOtp(string otp, Guid userId)
        {
            return await _context.UserCreadentials.Where(x => x.UserId == userId).ExecuteUpdateAsync(u => u.SetProperty(x => x.OTP, otp));
        }


    }
}
