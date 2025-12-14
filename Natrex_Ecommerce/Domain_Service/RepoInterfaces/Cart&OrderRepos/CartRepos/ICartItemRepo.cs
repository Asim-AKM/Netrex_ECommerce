using Domain_Service.Entities.CartAndOrderModule;

namespace Domain_Service.RepoInterfaces.Cart_OrderRepos
{
    public interface ICartItemRepo
    {
        //All the comented method will be used in the service 
        //Task<CartItem> Create(CartItem item);
        //Task<CartItem> Update(CartItem item);
        //Task<bool> Delete(CartItem item);
        //Task<CartItem> GetById(Guid id);
        //Task SaveChangesAsync();
        //Task<IEnumerable<CartItem>> GetCartItemsByCartId(Guid cartId);
        Task<CartItem> GetCartItem(Guid cartId, Guid productId);
    }
}
