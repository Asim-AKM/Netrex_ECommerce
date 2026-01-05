namespace Application_Service.DTO_s.CartAndOrderDtos.CartDtos
{
    public record UpdateCartDto
     (
        /// <summary>
        /// The unique identifier of the Cart to update.
        /// This field is system-generated and required to identify the cart in the system.
        /// </summary>
        Guid CartId,

        /// <summary>
        /// The unique identifier of the Customer associated with the cart.
        /// This field may be updated depending on business rules.
        /// </summary>
        Guid CustomerId
    );

}
