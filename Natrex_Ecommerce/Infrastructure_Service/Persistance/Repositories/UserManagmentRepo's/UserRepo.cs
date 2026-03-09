namespace Infrastructure_Service.Persistance.Repositories.Users
{
    internal class UserRepo : Repository<User>, IUserRepo
    {
        private readonly ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context) : base(context)
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
