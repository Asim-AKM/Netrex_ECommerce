namespace Infrastructure_Service.Persistance.Repositories.CartAndOrderRepo.CartRepo
{
    public class CartRepo: Repository<Cart>, ICartRepo
    {
        private readonly ApplicationDbContext _context;

        public CartRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
