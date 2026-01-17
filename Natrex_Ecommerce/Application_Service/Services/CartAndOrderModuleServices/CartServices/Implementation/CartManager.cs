using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartMappers;
using Application_Service.DTO_s.CartAndOrderDtos.CartDtos;
using Application_Service.Services.CartAndOrderModuleServices.CartServices.Interface;
using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.CartAndOrderModuleServices.CartServices.Implementation
{
    public class CartManager : ICartManager
    {
        private readonly IRepository<Cart> _cartRepository;

        public CartManager(IRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<ApiResponse<GetCartDto>> CreateAsync(AddCartDto dto)
        {
            var cart = dto.Map();

            await _cartRepository.Create(cart);
            await _cartRepository.SaveChangesAsync();

            return ApiResponse<GetCartDto>.Success(cart.Map(),"Cart created successfully"  );
        }

        public async Task<ApiResponse<bool>> DeleteAsync(Guid cartId)
        {
            var isDeleted = await _cartRepository.Delete(cartId);

             
            if (!isDeleted)
            {
                return ApiResponse<bool>.Fail(false, "Cart not found", ResponseType.NotFound);
                
            }

            
            await _cartRepository.SaveChangesAsync();

            
            return ApiResponse<bool>.Success(true, "Cart deleted successfully");
                
             
        }

        public async Task<ApiResponse<List<GetCartDto>>> GetAllAsync()
        {
            var carts = await _cartRepository.GetAll();
            
            var result = carts.Select(x=>x.Map()).ToList();

            return ApiResponse<List<GetCartDto>>.Success(
                result, "Carts retrieved successfully"
            );
        }

        public async Task<ApiResponse<GetCartDto>> GetByIdAsync(Guid cartId)
        {
             
            var cart = await _cartRepository.GetById(cartId);

             
            if (cart is null)
            {
                return ApiResponse<GetCartDto>.Fail( "Cart not found", ResponseType.NotFound );

            }
  
            return ApiResponse<GetCartDto>.Success(
                cart.Map(),
                "Cart retrieved successfully"
            );
        }

        public async Task<ApiResponse<bool>> UpdateAsync(UpdateCartDto dto)
        {
            
            var cart = await _cartRepository.GetById(dto.CartId);

            if (cart is null)
            {
                return ApiResponse<bool>.Fail(false, "Cart not found", ResponseType.NotFound);
   
            }

            cart =dto.Map(cart);

            await _cartRepository.Update(cart);
            await _cartRepository.SaveChangesAsync();

            return ApiResponse<bool>.Success(true, "Cart updated successfully");
                 
             
        }
    }

}
 
