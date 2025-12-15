namespace Application_Service.DTO_s.SellerDtos
{
    public  record GetAllSellerDto
    (
        Guid SellerId,
        Guid UserId,
        Guid ShopId,
        string StoreName,
        string StoreDescription,
        string Address
    );
}
