using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.Cart_OrderDtos.CartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.CartAndOrderModuleServices.Interface
{
    public interface ICartManager
    {


        Task<ApiResponse<GetCartDto>> CreateAsync(AddCartDto dto);

        Task<ApiResponse<GetCartDto>> GetByIdAsync(Guid cartId);

        Task<ApiResponse<List<GetCartDto>>> GetAllAsync();

        Task<ApiResponse<bool>> UpdateAsync(UpdateCartDto dto);

        Task<ApiResponse<bool>> DeleteAsync(Guid cartId);
    }

}

