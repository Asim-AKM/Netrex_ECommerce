using Application_Service.DTO_s.CartAndOrderDTOs.CartDtos;
using Domain_Service.Entities.CartAndOrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.CartAndOrderMappers.CartMappers
{
    public static class CartMapper
    {
        // AddCartDto → Cart
        public static Cart ToEntity(AddCartDto dto)
        {
            return new Cart
            {
                CartId = Guid.NewGuid(), // system-generated
                CustomerId = dto.CustomerId
            };
        }

        // UpdateCartDto → Cart (update existing tracked entity)
        public static void MapUpdate(UpdateCartDto dto, Cart cart)
        {
            cart.CustomerId = dto.CustomerId;
            // CartId is system-generated; do not modify
        }

        // Cart → GetCartDto
        public static GetCartDto ToGetDto(Cart cart)
        {
            return new GetCartDto(
                cart.CartId,
                cart.CustomerId
            );
        }

        // Cart → UpdateCartDto (optional, useful for edit forms)
        public static UpdateCartDto ToUpdateDto(Cart cart)
        {
            return new UpdateCartDto(
                cart.CartId,
                cart.CustomerId
            );
        }

        // Cart → AddCartDto (optional, rarely used, e.g., cloning)
        public static AddCartDto ToAddDto(Cart cart)
        {
            return new AddCartDto(
                cart.CustomerId
            );
        }
    }
}
