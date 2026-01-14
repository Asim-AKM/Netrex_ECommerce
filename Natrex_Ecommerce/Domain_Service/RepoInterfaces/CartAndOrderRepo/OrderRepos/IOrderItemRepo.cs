using Domain_Service.Entities.CartAndOrderModule;

namespace Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos
{
    public interface IOrderItemRepo
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId);
    }
}
