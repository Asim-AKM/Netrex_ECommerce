using Domain_Service.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Entities.PaymentAndPayout.PaymentSystemModule
{
    public class PaymentDetail
    {
        [Key]
        public Guid PaymentDetailId { get; set; }
        public Guid OrderId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public PaymentStatus PaymentStatus { get; set; }
        public double AmountPaid { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
