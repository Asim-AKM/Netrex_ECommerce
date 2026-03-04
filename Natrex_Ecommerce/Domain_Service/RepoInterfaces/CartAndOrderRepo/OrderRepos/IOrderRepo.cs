using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos
{
    public interface IOrderRepo : IRepository<Order>
    {       
        Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid customerId);
    }
}
