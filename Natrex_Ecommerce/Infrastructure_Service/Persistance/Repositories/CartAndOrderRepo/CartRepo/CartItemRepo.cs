using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.CartRepo
{
    public class CartItemRepo: Repository<CartItem>, ICartItemRepo
    {
        private readonly ApplicationDbContext _context;

        public CartItemRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<CartItem?> GetCartItem(Guid cartId, Guid productId)
        {
            return await _context.CartItems.FirstOrDefaultAsync(c => c.CartId == cartId && c.ProductId == productId);
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartId(Guid cartId)
        {
            return await _context.CartItems.Where(c => c.CartId == cartId).ToListAsync()?? new List<CartItem>();
        }
    }
}
