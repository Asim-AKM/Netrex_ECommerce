using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.PaymentAndPayout
{
    public class PaymentDetailRepo : IPaymentDetailRepo
    {
        private readonly ApplicationDbContext _context;
        public PaymentDetailRepo(ApplicationDbContext context)
        {
            _context = context;
        }

       
    }
}
