using Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos;
using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.Entities.ProductAndCategoryModule;

namespace Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartItemMappers
{
    public static class CartItemToGetCartItemDtoMapper
    {
        public static GetCartItemDto Map(this CartItem cartItem,Product product,string image)
        {
            return new GetCartItemDto(cartItem.CartItemId,product.ProductName,product.ProductDescription,product.Price,cartItem.Quantity);
        }
    }
}
