using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartItemMappers;
using Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos;
using Application_Service.Services.CartAndOrderModuleServices.Interface;
using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos;
using Domain_Service.RepoInterfaces.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.CartAndOrderModuleServices.Implementation
{
    public class CartItemManager:ICartItemManager
    {
        private readonly IRepository<CartItem> _cartItemRepo;
        private readonly ICartItemRepo _cartItemCustomRepo; 

        public CartItemManager(IRepository<CartItem> cartItemRepo, ICartItemRepo cartItemCustomRepo)
        {
            _cartItemRepo = cartItemRepo;
            _cartItemCustomRepo = cartItemCustomRepo;
        }

       
        public async Task<ApiResponse<GetCartItemDto>> CreateAsync(AddCartItemDto dto)
        {
            var cartItem = dto.Map(); 

            await _cartItemRepo.Create(cartItem);

            await _cartItemRepo.SaveChangesAsync();

            return ApiResponse<GetCartItemDto>.Success(cartItem.Map(), "Cart item created successfully");
        }

        
        public async Task<ApiResponse<GetCartItemDto>> GetByIdAsync(Guid cartItemId)
        {
            var cartItem = await _cartItemRepo.GetById(cartItemId);

            if (cartItem == null)
            {

                return ApiResponse<GetCartItemDto>.Fail("Cart item not found", ResponseType.NotFound);
            }

            return ApiResponse<GetCartItemDto>.Success(cartItem.Map(), "Cart item retrieved successfully");
        }

        
        public async Task<ApiResponse<List<GetCartItemDto>>> GetAllAsync()
        {
            var cartItems = await _cartItemRepo.GetAll();

            var result = cartItems.Select(x => x.Map()).ToList();

            return ApiResponse<List<GetCartItemDto>>.Success(result, "Cart items retrieved successfully");
        }

        
        public async Task<ApiResponse<bool>> UpdateAsync(UpdateCartItemDto dto)
        {
            var existing = await _cartItemRepo.GetById(dto.CartItemId);

            if (existing == null)
            {

                return ApiResponse<bool>.Fail(false, "Cart item not found", ResponseType.NotFound);
            }

            var updatedValues = dto.Map();
            existing.Quantity = updatedValues.Quantity;

            await _cartItemRepo.Update(existing);

            await _cartItemRepo.SaveChangesAsync();

            return ApiResponse<bool>.Success(true, "Cart item updated successfully");
        }

        
        public async Task<ApiResponse<bool>> DeleteAsync(Guid cartItemId)
        {
            var deleted = await _cartItemRepo.Delete(cartItemId);
            if (!deleted)
            { 
                return ApiResponse<bool>.Fail(false, "Cart item not found", ResponseType.NotFound);
            }

            await _cartItemRepo.SaveChangesAsync();

            return ApiResponse<bool>.Success(true, "Cart item deleted successfully");
        }

        
        public async Task<ApiResponse<GetCartItemDto>> GetByCartAndProductAsync(Guid cartId, Guid productId)
        {
            var cartItem = await _cartItemCustomRepo.GetCartItem(cartId, productId);
            if (cartItem == null)
                return ApiResponse<GetCartItemDto>.Fail("Cart item not found", ResponseType.NotFound);

            return ApiResponse<GetCartItemDto>.Success(cartItem.Map(), "Cart item retrieved successfully");
        }
    }
}

