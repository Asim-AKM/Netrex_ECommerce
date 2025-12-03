using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Entities.SellerModule
{
    public class ShopDetail
    {
        public Guid ShopId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
