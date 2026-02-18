namespace Application_Service.DTO_s.ProductDTOS
{
    public record AddProductReviewsDto(
    Guid ReviewId,
    Guid ProductId,
    Guid CustomerId,
    int Rating,
    string Comment,
    DateTime CreatedAt,
    bool IsApproved
    );

}
