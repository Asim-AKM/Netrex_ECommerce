namespace Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.OrderRepo
{
    public class OrderRepo : Repository<Order>, IOrderRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid customerId)
        {
            return await _context.Orders.Where(x => x.CustomerId == customerId).ToListAsync();
        }
    }
}
