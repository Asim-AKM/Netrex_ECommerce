using Domain_Service.Entities.SellerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.RepoInterfaces.SellerAndShopDetails
{
    public interface ISellerRepository
    {
        Task<Seller> GetAllSellers();
    }
}
