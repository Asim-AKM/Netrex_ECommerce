using Domain_Service.Entities.CartAndOrderModule;

namespace Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos
{
    public interface ICartItemRepo
    {
        /// <summary>
        /// Get a cart item by cartId and productId.
        /// Returns null if not found.
        /// </summary>
        Task<CartItem?> GetCartItem(Guid cartId, Guid productId);
    }
}
