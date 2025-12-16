using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.Cart_OrderRepos;

namespace Infrastructure_Service.Persistance.Repositories.Cart_OrderRepo.CartRepo
{
    public class CartItemRepo : ICartItemRepo
    {
        public Task<CartItem> GetCartItem(Guid cartId, Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
