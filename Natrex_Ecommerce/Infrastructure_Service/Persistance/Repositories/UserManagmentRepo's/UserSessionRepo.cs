namespace Infrastructure_Service.Persistance.Repositories.UserManagmentRepo_s
{
    public class UserSessionRepo : Repository<UserSession>, IUserSessionRepo
    {
        private readonly ApplicationDbContext _context;
        public UserSessionRepo(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<UserSession?> GetSessionByFK(Guid userId)=>
            await _context.UserSessions.Where(u => u.UserId == userId).FirstOrDefaultAsync();

        public async Task<UserSession?> GetSessionByRefreshToken(string refreshToken)=>
            await _context.UserSessions.Where(u => u.RefreshToken == refreshToken).FirstOrDefaultAsync();

    }
}
