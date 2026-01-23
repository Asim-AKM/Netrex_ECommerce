using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.CartAndOrderModuleMappers.CartItemMappers;
using Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos;
using Application_Service.Services.CartAndOrderModuleServices.CartServices.Interface;
using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.CartAndOrderModuleServices.CartServices.Implementation
{
    public class CartItemManager(IUnitOfWork unitOfWork,IRepository<CartItem> genericRepo,ICartItemRepo repo):ICartItemManager
    {
       
        public async Task<ApiResponse<bool>> CreateAsync(AddCartItemDto cartItemDto,Guid customerId)
        {
            var cart = await unitOfWork.Carts.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if(cart == null)
            {
                cart = new Cart
                {
                    CartId = Guid.NewGuid(),
                    CustomerId = customerId
                };
                await unitOfWork.Carts.Create(cart);
            }

            var cartItem = await  repo.GetCartItem(cart.CartId, cartItemDto.ProductId);
            if(cartItem != null)
            {
                cartItem.Quantity += cartItemDto.Quantity;
                await unitOfWork.CartItems.Update(cartItem);
            }
            else
            { 
                var data=cartItemDto.Map(cart.CartId);
            }
            if(await unitOfWork.SaveChangesAsync()<=0)
            {
                return ApiResponse<bool>.Fail(false, "Failed to add cart item", ResponseType.InternalServerError);
            }

            return ApiResponse<bool>.Success(true,"",ResponseType.Ok);
        }
        public async Task<ApiResponse<List<GetCartItemDto>>> GetAllAsync(Guid customerId)
        {
            var cart=await unitOfWork.Carts.FirstOrDefaultAsync(c=>c.CustomerId==customerId);
            if (cart == null)
                return ApiResponse<List<GetCartItemDto>>.Fail("Cart not found", ResponseType.NotFound);

            var cartItem=await repo.GetCartItemsByCartId(cart.CartId);
            if(cartItem==null)
            {
                return ApiResponse<List<GetCartItemDto>>.Fail("No cart items found", ResponseType.NotFound);
            }
            var result=new List<GetCartItemDto>();
            foreach (var item in cartItem)
            { 
                var product = await unitOfWork.Products.GetById(item.ProductId);
                if (product != null)
                { 
                    result.Add(item.Map(product));
                }
            }
            return ApiResponse<List<GetCartItemDto>>.Success(result, "Cart items retrieved successfully");
        }
        public async Task<ApiResponse<bool>> IncreaseQuantityAsync(Guid cartItemId)
        {
            var item = await genericRepo.GetById(cartItemId);
            if (item == null)
                return ApiResponse<bool>.Fail("Item not found");

            item.Quantity += 1;
            await genericRepo.Update(item);
            if(await unitOfWork.SaveChangesAsync() <= 0)
            {
                return ApiResponse<bool>.Fail("Failed to increase quantity", ResponseType.InternalServerError);
            }

            return ApiResponse<bool>.Success(true,"Quantity Increased successfully");
        }
        public async Task<ApiResponse<bool>> DecreaseQuantityAsync(Guid cartItemId)
        {
            var item = await genericRepo.GetById(cartItemId);
            if (item == null)
                return ApiResponse<bool>.Fail("Item not found");

            if (item.Quantity <= 1)
                return ApiResponse<bool>.Fail("Quantity cannot be less than 1");

            item.Quantity -= 1;
            await genericRepo.Update(item);
            if(await unitOfWork.SaveChangesAsync()<=0)
            {
                return ApiResponse<bool>.Fail("Failed to decrease quantity", ResponseType.InternalServerError);
            }

            return ApiResponse<bool>.Success(true,"Quantity Decreases SuccessFully",ResponseType.Ok);
        }
        public async Task<ApiResponse<bool>> DeleteAsync(Guid cartItemId)
        {
            if (await genericRepo.Delete(cartItemId))
            { 
                return ApiResponse<bool>.Fail(false, "Cart item not found", ResponseType.NotFound);
            }
            await genericRepo.SaveChangesAsync();
            return ApiResponse<bool>.Success(true, "Cart item deleted successfully");
        }     
    }
}

