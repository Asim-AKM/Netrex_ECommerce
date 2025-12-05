using Domain_Service.Entities.PaymentAndPayout;

namespace Domain_Service.RepoInterfaces.PaymentAndPayout
{
    public interface IInvoiceRepo
    {
        Task GenerateInvoice(Invoice invoice);
        Task<Invoice> GetInvoiceById(Guid invoiceId);
    }
}
