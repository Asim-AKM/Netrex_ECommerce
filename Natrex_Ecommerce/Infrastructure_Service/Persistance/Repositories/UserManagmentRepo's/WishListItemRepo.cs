namespace Infrastructure_Service.Persistance.Repositories.UserManagmentRepo_s
{
    public class WishListItemRepo : Repository<WishListItem>, IWishListItemRepo
    {
        private readonly ApplicationDbContext _context;
        public WishListItemRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public IQueryable<WishListItem> QueryWishListItems()
        {
            return _context.WishListItems.AsQueryable();
        }
    }
}
