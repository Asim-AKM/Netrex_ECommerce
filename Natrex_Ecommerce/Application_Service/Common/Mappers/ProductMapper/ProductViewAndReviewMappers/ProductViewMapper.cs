using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductManagmentModule;

namespace Application_Service.Common.Mappers.ProductMapper.ProductViewAndReviewMappers
{
    public static class ProductViewMapper
    {
        public static ProductView ToEntity(this AddProductViewDto dto)
        {
            return new ProductView
            {
                ProductViewId = Guid.NewGuid(),
                ProductId = dto.ProductId,
                    UserId = dto.UserId,
                IPAddress = dto.IPAddress,
                ViewedAt = DateTime.UtcNow
            };
        }

        public static AddProductViewDto ToDto(this ProductView entity)
        {
            return new AddProductViewDto
           (
            entity.ProductViewId,
            entity.ProductId,
            entity.UserId,
            entity.IPAddress,
            entity.ViewedAt
            );
        }
    }
}