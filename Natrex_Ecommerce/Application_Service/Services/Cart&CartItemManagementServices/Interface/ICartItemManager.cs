using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.CartAndOrderModuleServices.Interface
{
    public interface ICartItemManager
    {
        Task<ApiResponse<GetCartItemDto>> CreateAsync(AddCartItemDto dto);

        Task<ApiResponse<GetCartItemDto>> GetByIdAsync(Guid cartItemId);

        Task<ApiResponse<List<GetCartItemDto>>> GetAllAsync();

        Task<ApiResponse<bool>> UpdateAsync(UpdateCartItemDto dto);

        Task<ApiResponse<bool>> DeleteAsync(Guid cartItemId);

        // Extra method for CartItem: Get by CartId & ProductId
        Task<ApiResponse<GetCartItemDto>> GetByCartAndProductAsync(Guid cartId, Guid productId);
    }
}
