using Domain_Service.Entities.ProductManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.UserManagmentRepo_s
{
    public class WishListRepo : IWishListRepo
    {
        private readonly ApplicationDbContext _context;
        public WishListRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<WishListItem>> GetAllWishListItemsByWishListId(Guid wishListId)
        {
            return await _context.WishListItems.Where(w => w.WishListId == wishListId).ToListAsync();
        }
    }
}
