namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{
    public class PaymentManager : IPaymentManager
    {
        public Task<string> AuthorizePaymentAsync(PaymentDetailDto paymentDetailDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CapturePaymentAsync(string PaymentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefundPaymentAsync(string paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VoidPaymentAsync(string paymentId)
        {
            throw new NotImplementedException();
        }
    }
}
