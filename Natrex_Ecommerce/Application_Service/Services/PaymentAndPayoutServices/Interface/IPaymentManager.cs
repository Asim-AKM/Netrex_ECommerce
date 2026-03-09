using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.PaymentAndPayoutServices.Interface
{
    public interface IPaymentManager
    {

        Task<string> AuthorizePaymentAsync(PaymentDetailDto paymentDetailDto);

        Task<bool>CapturePaymentAsync(string PaymentId);
        Task<bool> VoidPaymentAsync(string paymentId);
        Task<bool> RefundPaymentAsync(string paymentId);
    }
}
