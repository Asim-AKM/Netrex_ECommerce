namespace Application_Service.DTO_s.ProductDTOS
{
    public  record GetProductDto( Guid productId, Guid ImgeId, Guid sellerId, Guid productcatorgayId, string productName, string productDescription, double price,
                                                     double discount, int stockQuantity, string ImageUrl, string CloudPublicId, DateTime createdAt, DateTime updatedAt);


}
