namespace Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos
{
    public interface IOrderRepo
    {       
        Task<IEnumerable<Order>> GetOrdersByCustomerId(Guid customerId);
    }
}
