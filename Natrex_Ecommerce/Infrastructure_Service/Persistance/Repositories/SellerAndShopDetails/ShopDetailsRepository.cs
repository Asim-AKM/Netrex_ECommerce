using Domain_Service.Entities.SellerModule;
using Domain_Service.RepoInterfaces.SellerAndShopDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Service.Persistance.Repositories.SellerAndShopDetails
{
    public class ShopDetailsRepository : IShopDetailsRepository
    {
        public Task<ShopDetail> GetAllShopDetails()
        {
            throw new NotImplementedException();
        }
    }
}
