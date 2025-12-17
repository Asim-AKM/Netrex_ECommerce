using Application_Service.DTO_s.CartAndOrderDTOs.CartItemDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderMappers.CartItemMappers
{
    public static class CartItemMapper
    {
        // AddCartItemDto → CartItem
        public static CartItem MapToEntity(AddCartItemDto dto)
        {
            return new CartItem
            {
                CartItemId = Guid.NewGuid(),
                CartId = dto.CartId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };
        }

        // UpdateCartItemDto → CartItem (update existing tracked entity)
        public static void MapUpdate(UpdateCartItemDto dto, CartItem cartItem)
        {
            cartItem.Quantity = dto.Quantity;
        }

        // CartItem → GetCartItemDto
        public static GetCartItemDto ToGetDto(CartItem cartItem)
        {
            return new GetCartItemDto(
                cartItem.CartItemId,
                cartItem.CartId,
                cartItem.ProductId,
                cartItem.Quantity
            );
        }

        // CartItem → UpdateCartItemDto (optional, useful for returning editable form)
        public static UpdateCartItemDto MapToUpdateDto(CartItem cartItem)
        {
            return new UpdateCartItemDto(
                cartItem.CartItemId,
                cartItem.Quantity
            );
        }

        // CartItem → AddCartItemDto (optional, rarely used, e.g., cloning)
        public static AddCartItemDto MapToAddDto(CartItem cartItem)
        {
            return new AddCartItemDto(
                cartItem.CartId,
                cartItem.ProductId,
                cartItem.Quantity
            );
        }
    }
}

