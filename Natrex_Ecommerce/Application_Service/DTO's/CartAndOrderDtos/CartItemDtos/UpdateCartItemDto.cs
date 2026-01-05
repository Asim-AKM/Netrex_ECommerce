namespace Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos
{
    public record UpdateCartItemDto
     (
        /// <summary>
        /// The unique identifier of the CartItem.
        /// This field is system-generated and uniquely identifies the item in the database.
        /// </summary>
        Guid CartItemId,

        /// <summary>
        /// The unique identifier of the Cart to which this item belongs.
        /// </summary>
        Guid CartId,

        /// <summary>
        /// The unique identifier of the Product associated with this CartItem.
        /// </summary>
        Guid ProductId,

        /// <summary>
        /// The quantity of the product in the cart item.
        /// </summary>
        int Quantity
    );
}
