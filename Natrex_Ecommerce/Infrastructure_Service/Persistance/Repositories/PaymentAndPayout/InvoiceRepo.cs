using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Infrastructure_Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Service.Persistance.Repositories.PaymentAndPayout
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly ApplicationDbContext _context;
        public InvoiceRepo(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
       
    }
}
