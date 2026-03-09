namespace Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.OrderRepo
{
    public class OrderItemRepo : Repository<OrderItem>, IOrderItemRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderItemRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId)
        {
            return await _context.OrderItems.Where(oi=> oi.OrderId == orderId).ToListAsync();
        }
    }
}
