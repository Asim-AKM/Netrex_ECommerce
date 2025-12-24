using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Entities.SellerModule
{
    public class ShopDetail
    {
        [Key]
        public Guid ShopDetailsId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
