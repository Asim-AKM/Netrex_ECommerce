using Application_Service.DTO_s.ProductDTOS;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.ProductMapper
{
    public static class GetProductCatagoryMapper
    {
        public static ProductCategoryDto Map(this ProductCategory categories)
        {
            return new ProductCategoryDto(categories.CategoryId, categories.CategoryName);
        }
    }
}
