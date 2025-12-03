using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Entities.CartAndOrderModule
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public bool OrderStatus { get; set; }
        public bool PaymentStatus { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
