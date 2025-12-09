using Domain_Service.Entities.PaymentAndPayout;

namespace Domain_Service.RepoInterfaces.PaymentAndPayout
{
    /// <summary>
    /// Repository interface for performing data operations on <see cref="Invoice"/> entities.
    /// Defines the contract that any invoice repository implementation must follow.
    /// </summary>
    /// <remarks>
    /// Part of the Domain/Repository layer in Clean Architecture.
    /// Implementations should handle persistence, retrieval, and querying of invoices
    /// without exposing the underlying data access logic to the application layer.
    /// </remarks>
    public interface IInvoiceRepo
    {
        /// <summary>
        /// (Optional) Add custom methods for invoice-specific queries here.
        /// For example:
        /// <list type="bullet">
        /// <item>Get invoices by OrderId</item>
        /// <item>Get invoices by date range</item>
        /// <item>Get total revenue from invoices</item>
        /// </list>
        /// </summary>
    }
}
