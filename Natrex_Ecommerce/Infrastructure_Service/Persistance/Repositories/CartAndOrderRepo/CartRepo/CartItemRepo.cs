using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos;

namespace Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.CartRepo
{
    public class CartItemRepo : ICartItemRepo
    {
        public Task<CartItem> GetCartItem(Guid cartId, Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
