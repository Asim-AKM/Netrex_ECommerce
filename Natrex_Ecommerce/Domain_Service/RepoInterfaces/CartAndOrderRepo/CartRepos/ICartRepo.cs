using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos
{
    public interface ICartRepo : IRepository<Cart>
    {
        //All these methods belongs to generic repository so here is just decleration not the implementation
        //Task<Cart> Create(Cart cart);
        //Task<Cart> Update(Cart cart);
        //Task<bool> Delete(Cart cart);
        //Task<Cart> GetById(Guid cartId);
        //Task SaveChangesAsync();
        //Task<Cart> GetCartByCustomerId(Guid customerId);
        //Task<bool> CartExists(Guid customerId);
    }
}
