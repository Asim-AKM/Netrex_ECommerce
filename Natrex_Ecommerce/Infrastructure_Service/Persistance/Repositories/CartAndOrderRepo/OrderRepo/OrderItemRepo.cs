using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.OrderRepo
{
    public class OrderItemRepo(ApplicationDbContext context) : IOrderItemRepo
    {
        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId)
        {
            return await context.OrderItems.Where(oi=> oi.OrderId == orderId).ToListAsync();
        }
    }
}
