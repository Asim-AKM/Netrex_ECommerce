using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos
{
    public interface ICartItemRepo : IRepository<CartItem>
    {
        /// <summary>
        /// Get a cart item by cartId and productId.
        /// Returns null if not found.
        /// </summary>
        Task<CartItem?> GetCartItem(Guid cartId, Guid productId);
        Task<IEnumerable<CartItem>> GetCartItemsByCartId(Guid cartId);
    }
}
