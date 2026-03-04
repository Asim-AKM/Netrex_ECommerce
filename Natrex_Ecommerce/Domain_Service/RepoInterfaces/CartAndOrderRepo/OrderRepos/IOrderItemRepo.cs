using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos
{
    public interface IOrderItemRepo : IRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId);
    }
}
