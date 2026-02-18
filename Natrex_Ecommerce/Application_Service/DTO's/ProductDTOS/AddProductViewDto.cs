namespace Application_Service.DTO_s.ProductDTOS
{
    public record AddProductViewDto(
    Guid ProductViewId,
    Guid ProductId,
    Guid? UserId,
    string IPAddress,   
    DateTime ViewedAt
    );
    
}
