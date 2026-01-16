using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos;

namespace Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.CartRepo
{
    public class CartItemRepo:ICartItemRepo
    {
        private readonly ApplicationDbContext _context;

        public CartItemRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CartItem?> GetCartItem(Guid cartId, Guid productId)
        {
            return await _context.CartItems.FirstOrDefaultAsync(c => c.CartId == cartId && c.ProductId == productId);
        }
    }
}
}
