using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderMappers;
using Application_Service.DTO_s.CartAndOrderDtos.OrderDtos;
using Application_Service.Services.CartAndOrderModuleServices.OrderServices.Interface;
using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.Entities.ProductAndCategoryModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.CartRepos;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.CartAndOrderModuleServices.OrderServices.Implementation
{
    public class OrderManager(IUnitOfWork _unitOfWork,IRepository<Order> genericRepo,IOrderRepo orderRepo, ICartItemRepo cartItemRepo) : IOrderManager
    {
        public async Task<ApiResponse<GetOrderDto>> CreateOrderAsync(AddOrderDto orderDto)
        {
            var cart=await _unitOfWork.Carts.FirstOrDefaultAsync(c=>c.CustomerId==orderDto.CustomerId);
            if (cart == null)
            {
                 return ApiResponse<GetOrderDto>.Fail("Cart Cannot Found",ResponseType.NotFound);
            }
            var cartItems =await cartItemRepo.GetCartItemsByCartId(cart.CartId);
            if (!cartItems.Any())
            {
               return ApiResponse<GetOrderDto>.Fail("Cart is Empty",ResponseType.NotFound);
            }
            var order = orderDto.Map();
            var productList = new List<(Product product, int quantity)>();
            foreach (var items in cartItems)
            {
                var product = await _unitOfWork.Products.GetById(items.ProductId);
                if (product == null)
                    return ApiResponse<GetOrderDto>.Fail("Product not found", ResponseType.NotFound);
                if (product.StockQuantity < items.Quantity)
                    return ApiResponse<GetOrderDto>.Fail($"Product {product.ProductName} is out of stock", ResponseType.BadRequest);
                order.TotalAmount += items.Quantity * product.Price;
                productList.Add((product, items.Quantity));
                await _unitOfWork.CartItems.Delete(items.CartItemId);
            }   
            await _unitOfWork.Orders.Create(order);      
            foreach(var items in productList)
            {
                var orderItem = new OrderItem
                    {
                        OrderItemId = Guid.NewGuid(),
                        OrderId = order.OrderId,
                        ProductId = items.product.ProductId,
                        Quantity = items.quantity,
                        Price = items.product.Price,
                        PriceTotal = items.product.Price * items.quantity
                    };
             
                await _unitOfWork.OrderItems.Create(orderItem);
            }
            if(await _unitOfWork.SaveChangesAsync() <= 0)
            {
                return ApiResponse<GetOrderDto>.Fail("Failed to create order", ResponseType.InternalServerError);
            }  
            return ApiResponse<GetOrderDto>.Success(order.Map(),"Order created successfully", ResponseType.Ok);
        }
        public async Task<ApiResponse<bool>> CancelOrderAsync(Guid orderId)
        {
            var order=await genericRepo.GetById(orderId);
            if (order == null)
            {
                return ApiResponse<bool>.Fail("No such order is found", ResponseType.NoContent);
            }
            if (order.PaymentStatus == true)
                return ApiResponse<bool>.Fail("Paid order cannot be cancelled");
            var orderItem = (await _unitOfWork.OrderItems.GetAll()).Where(x => x.OrderId == order.OrderId).ToList();
            foreach(var item in orderItem)
            {
                await _unitOfWork.OrderItems.Delete(item.OrderItemId);
            }
            await _unitOfWork.Orders.Delete(order.OrderId);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<bool>.Success(true,"order is cancelled",ResponseType.Ok);
        }  
        public async Task<ApiResponse<GetOrderDto>> GetOrderByIdAsync(Guid orderId)
        {
            var order = await genericRepo.GetById(orderId);
            if (order == null)
            {
                return ApiResponse<GetOrderDto>.Fail("Order not found", ResponseType.NotFound);
            }
            return ApiResponse<GetOrderDto>.Success(order.Map(),"Order is fetched",ResponseType.Ok);
        }
        public async Task<ApiResponse<IEnumerable<GetOrderDto>>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            var order=await orderRepo.GetOrdersByCustomerId(customerId);
            if (order == null)
            {
                return ApiResponse<IEnumerable<GetOrderDto>>.Fail("this customer has no order yet", ResponseType.NotFound);
            }
            return ApiResponse<IEnumerable<GetOrderDto>>.Success(order.MapList(), "Order fetched successfully",ResponseType.Ok);
        }
        public async Task<ApiResponse<bool>> UpdateOrderStatusAsync(UpdateOrderDto updateOrderDto)
        {
            var order = await genericRepo.GetById(updateOrderDto.OrderId);
            if (order == null)
                return ApiResponse<bool>.Fail(false,"Order is null", ResponseType.NotFound);
            order.PaymentStatus=updateOrderDto.PaymentStatus;
            order.OrderStatus = updateOrderDto.OrderStatus;
            await genericRepo.Update(order);
            await genericRepo.SaveChangesAsync();
            return ApiResponse<bool>.Success(true, "Order updated successfully", ResponseType.Ok);
        }
    }
}
