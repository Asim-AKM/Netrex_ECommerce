namespace Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos
{
    public record AddCartItemDto
        (
        /// <summary>
        /// The unique identifier of the Product to add to the cart.
        /// This is required to identify the product being added.
        /// </summary>
        Guid ProductId,
        /// <summary>
        /// The quantity of the product to add to the cart.
        /// Must be greater than zero.
        /// </summary>
        int Quantity
        );
}
