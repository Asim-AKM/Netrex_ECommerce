using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.OrderRepo
{
    public class OrderRepo(ApplicationDbContext context) : IOrderRepo
    {
        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid customerId)
        {
            return await context.Orders.Where(x => x.CustomerId == customerId).ToListAsync();
        }
    }
}
