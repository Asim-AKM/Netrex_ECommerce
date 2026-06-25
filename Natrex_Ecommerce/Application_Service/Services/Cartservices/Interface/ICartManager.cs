using Application_Service.DTO_s.CartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.Cartservices.Interface
{
    public interface ICartManager
    {
        Task<AddCartDto> AddCart(AddCartDto addCartDto);
        Task<bool> RemoveCart(Guid CartId);
        Task<UpdateCartDto> UpdateCart(UpdateCartDto updateCartDto);
        Task<GetCartDto> GetCartById(Guid CartId);
    }
}
