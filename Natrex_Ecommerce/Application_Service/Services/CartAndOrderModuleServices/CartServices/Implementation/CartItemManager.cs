namespace Application_Service.Services.CartAndOrderModuleServices.CartServices.Implementation
{
    public class CartItemManager(IUnitOfWork unitOfWork):ICartItemManager
    {
       
        public async Task<ApiResponse<bool>> CreateAsync(AddCartItemDto cartItemDto,Guid userId)
        {
            var cart = await unitOfWork.CartRepo.FirstOrDefaultAsync(c => c.CustomerId == userId);
            if(cart == null)
            {
                cart = new Cart
                {
                    CartId = Guid.NewGuid(),
                    CustomerId = userId,
                };
                await unitOfWork.CartRepo.Create(cart);
            }
            var proudct= await unitOfWork.ProductRepo.GetById(cartItemDto.ProductId);
            if(proudct == null)
                return ApiResponse<bool>.Fail("Product not found", ResponseType.NotFound);
            if (proudct.StockQuantity <= 0)
                return ApiResponse<bool>.Fail("Product is out of stock", ResponseType.BadRequest);
            var cartItem = await  unitOfWork.CartItemRepo.GetCartItem(cart.CartId, cartItemDto.ProductId);
            if(cartItem != null)
            {
                cartItem.Quantity += cartItemDto.Quantity;
                await unitOfWork.CartItemRepo.Update(cartItem);
            }
            else
            { 
                await unitOfWork.CartItemRepo.Create(cartItemDto.Map(cart.CartId));
            }
            if(await unitOfWork.SaveChangesAsync()<=0)
            {
                return ApiResponse<bool>.Fail("Failed to add cart item", ResponseType.InternalServerError);
            }

            return ApiResponse<bool>.Success(true,"",ResponseType.Ok);
        }
        public async Task<ApiResponse<List<GetCartItemDto>>> GetAllAsync(Guid customerId)
        {
            var cart=await unitOfWork.CartRepo.FirstOrDefaultAsync(c=>c.CustomerId==customerId);
            if (cart == null)
                return ApiResponse<List<GetCartItemDto>>.Fail("Cart not found", ResponseType.NotFound);
            var cartItem=await unitOfWork.CartItemRepo.GetCartItemsByCartId(cart.CartId);
            if(cartItem==null)
            {
                return ApiResponse<List<GetCartItemDto>>.Fail("No cart items found", ResponseType.NotFound);
            }
            var result=new List<GetCartItemDto>();
            foreach (var item in cartItem)
            { 
                var product = await unitOfWork.ProductRepo.GetById(item.ProductId);
                var productimage = await unitOfWork.ProductImageRepo.FirstOrDefaultAsync(x => x.ProductId == item.ProductId) ?? new  ProductImage();
                if (product != null)
                { 
                    result.Add(item.Map(product,productimage.ImageUrl));
                }
            }
            return ApiResponse<List<GetCartItemDto>>.Success(result, "Cart items retrieved successfully");
        }
        public async Task<ApiResponse<bool>> IncreaseQuantityAsync(Guid cartItemId)
        {
            var item = await unitOfWork.CartItemRepo.GetById(cartItemId);
            if (item == null)
                return ApiResponse<bool>.Fail("Item not found");

            item.Quantity += 1;
            await unitOfWork.CartItemRepo.Update(item);
            if(await unitOfWork.SaveChangesAsync() <= 0)
            {
                return ApiResponse<bool>.Fail("Failed to increase quantity", ResponseType.InternalServerError);
            }

            return ApiResponse<bool>.Success(true,"Quantity Increased successfully");
        }
        public async Task<ApiResponse<bool>> DecreaseQuantityAsync(Guid cartItemId)
        {
            var item = await unitOfWork.CartItemRepo.GetById(cartItemId);
            if (item == null)
                return ApiResponse<bool>.Fail("Item not found");

            if (item.Quantity <= 1)
                return ApiResponse<bool>.Fail("Quantity cannot be less than 1");

            item.Quantity -= 1;
            await unitOfWork.CartItemRepo.Update(item);
            if(await unitOfWork.SaveChangesAsync()<=0)
            {
                return ApiResponse<bool>.Fail("Failed to decrease quantity", ResponseType.InternalServerError);
            }

            return ApiResponse<bool>.Success(true,"Quantity Decreases SuccessFully",ResponseType.Ok);
        }
        public async Task<ApiResponse<bool>> DeleteAsync(Guid cartItemId)
        {
            if (!(await unitOfWork.CartItemRepo.Delete(cartItemId)))
            { 
                return ApiResponse<bool>.Fail("Cart item not found", ResponseType.NotFound);
            }
            await unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Success(true, "Cart item deleted successfully");
        }     
    }
}

