namespace Infrastructure_Service.Persistance.Repositories.UserManagmentRepo_s
{
    public class CustomerRepo : Repository<Customer>, ICustomerRepo
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerbyFK(Guid userId)
        {
            return await _context.Customers.Where(x=>x.UserId==userId).FirstOrDefaultAsync()??new Customer();   
        }
    }
}
