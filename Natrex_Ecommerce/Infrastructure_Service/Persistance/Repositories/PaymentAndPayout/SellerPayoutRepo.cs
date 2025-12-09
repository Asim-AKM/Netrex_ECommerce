using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.PaymentAndPayout
{
    public class SellerPayoutRepo : ISellerPayoutRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public SellerPayoutRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
