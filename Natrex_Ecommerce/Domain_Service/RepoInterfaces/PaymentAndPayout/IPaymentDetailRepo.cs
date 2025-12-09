using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Domain_Service.RepoInterfaces.PaymentAndPayout
{
    /// <summary>
    /// Repository interface for handling data operations 
    /// related to <see cref="PaymentDetail"/> entities.
    /// <para>
    /// This interface exists to allow separation of concerns and 
    /// maintain clean architecture by abstracting the data access logic.
    /// </para>
    /// </summary>
    /// <remarks>
    /// Typically, this interface inherits CRUD operations from 
    /// a generic repository such as <see cref="IGenericRepo{T}"/>.
    /// <br/>
    /// Example:
    /// <code>
    /// public interface IPaymentDetailRepo : IGenericRepo&lt;PaymentDetail&gt;
    /// </code>
    /// </remarks>
    public interface IPaymentDetailRepo
    {
        // Add payment-specific custom operations here when needed.
        // Example:
        // Task<IEnumerable<PaymentDetail>> GetPaymentsByOrderId(Guid orderId);
    }
}
