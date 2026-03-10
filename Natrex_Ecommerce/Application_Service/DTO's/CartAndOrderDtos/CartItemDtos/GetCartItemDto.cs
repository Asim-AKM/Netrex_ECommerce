namespace Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos
{
    public record GetCartItemDto
     (
    
        Guid CartItemId,
        string  ProductName,
        string Description,
        double Price,
        string ImageUrl,
        int Quantity
    );
}
