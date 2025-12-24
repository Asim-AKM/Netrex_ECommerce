namespace Domain_Service.RepoInterfaces.PaymentAndPayout
{
    /// <summary>
    /// Defines contract for seller payout related data operations.
    /// </summary>
    /// <remarks>
    /// This interface represents the repository abstraction for managing
    /// seller payout entities in the Payment and Payout domain.
    /// 
    /// It follows the Repository Pattern and ensures that the Domain layer
    /// remains independent of data access implementation details.
    /// </remarks>
    public interface ISellerPayoutRepo
    {
        // Future payout-specific methods will be declared here
        // Example:
        // Task<SellerPayout> GetBySellerIdAsync(Guid sellerId);
    }
}
