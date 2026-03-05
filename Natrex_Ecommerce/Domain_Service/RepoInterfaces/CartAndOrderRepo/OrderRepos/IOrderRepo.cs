namespace Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos
{
    public interface IOrderRepo : IRepository<Order>
    {       
        Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid customerId);
    }
}
