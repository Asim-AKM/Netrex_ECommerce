using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.OrderRepo
{
    public class OrderItemRepo : Repository<OrderItem>, IOrderItemRepo
    {
        private readonly ApplicationDbContext _context;

        public OrderItemRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteByOrderId(Guid orderId)
        {
            var items = await _context.OrderItems
                              .Where(oi => oi.OrderId == orderId)
                              .ToListAsync();
            _context.OrderItems.RemoveRange(items);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId)
        {
            return await _context.OrderItems.Where(oi=> oi.OrderId == orderId).ToListAsync();
        }
    }
}
