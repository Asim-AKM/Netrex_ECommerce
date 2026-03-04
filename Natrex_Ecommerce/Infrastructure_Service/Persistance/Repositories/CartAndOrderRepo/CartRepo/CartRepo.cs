using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos;
using Infrastructure_Service.Data;
using Infrastructure_Service.Persistance.GenericRepository.Implementation;

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
