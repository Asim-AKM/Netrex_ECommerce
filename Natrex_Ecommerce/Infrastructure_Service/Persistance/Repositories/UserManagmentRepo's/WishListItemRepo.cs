using Domain_Service.Entities.ProductManagmentModule;
using Domain_Service.RepoInterfaces.UserManagment;
using Infrastructure_Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Service.Persistance.Repositories.UserManagmentRepo_s
{
    public class WishListItemRepo : IWishListItemRepo
    {
        private readonly ApplicationDbContext _context;
        public WishListItemRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IQueryable<WishListItem> QueryWishListItems()
        {
            return _context.WishListItems.AsQueryable();
        }
    }
}
