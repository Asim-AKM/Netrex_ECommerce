namespace Infrastructure_Service.Persistance.Repositories.UserCreadentials
{
    public class UserCreadentialRepo : Repository<UserCreadential>, IUserCreadentialRepo
    {
        private readonly ApplicationDbContext _context;
        public UserCreadentialRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<UserCreadential> GetCreadbyFK(Guid userId)
        {
            return await _context.UserCreadentials.AsNoTracking().Where(ur => ur.UserId == userId).FirstOrDefaultAsync() ?? new UserCreadential();
        }

        public async Task<int> UpdateOtp(string otp, DateTime? otpExpiry, Guid userId)
        {
            return await _context.UserCreadentials.Where(x => x.UserId == userId)
                .ExecuteUpdateAsync(u => u.SetProperty(x => x.OTP, otp)
                .SetProperty(x=>x.OTPExpiry, otpExpiry));

        }


    }
}
