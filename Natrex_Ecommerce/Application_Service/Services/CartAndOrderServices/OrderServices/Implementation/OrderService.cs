using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderMappers;
using Application_Service.DTO_s.CartAndOrderDtos.OrderDtos;
using Application_Service.Services.CartAndOrderServices.OrderServices.Interface;
using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos;
using Domain_Service.RepoInterfaces.GenericRepo;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.CartAndOrderServices.OrderServices.Implementation
{
    public class OrderService(IUnitOfWork _unitOfWork,IRepository<Order> genericRepo,IOrderRepo orderRepo) : IOrderService
    {
        public async Task<ApiResponse<GetOrderDto>> CreateOrderAsync(AddOrderDto orderDto)
        {
            var cart=await _unitOfWork.Carts.FirstOrDefaultAsync(c=>c.CustomerId==orderDto.CustomerId);
            if (cart == null)
            {
                 return ApiResponse<GetOrderDto>.Fail("Cart Cannot Found",ResponseType.NotFound);
            }
            var cartItems =(await _unitOfWork.CartItems.GetAll()).Where(x=>x.CartId==cart.CartId).ToList();//yaha pe me cartitem se get karoga jab cartitem k method ban jaye
            if (!cartItems.Any())
            {
               return ApiResponse<GetOrderDto>.Fail("Cart is Empty",ResponseType.NoContent);
            }
            var order = orderDto.Map();
            await _unitOfWork.Orders.Create(order);
            double totalAmount = 0;
            foreach(var items in cartItems)
            {
                var product =await _unitOfWork.Products.GetById(items.ProductId);
                if(product == null)
                {
                    return ApiResponse<GetOrderDto>.Fail("Product not found", ResponseType.NoContent);
                }
                var orderItem = new OrderItem
                {
                    OrderItemId = Guid.NewGuid(),
                    OrderId=order.OrderId,
                    ProductId=items.ProductId,
                    Quantity=items.Quantity,
                    Price=product.Price,
                    PriceTotal=product.Price*items.Quantity
                };
                totalAmount += orderItem.PriceTotal;
                await _unitOfWork.OrderItems.Create(orderItem);
            }
            order.TotalAmount = totalAmount;
            await _unitOfWork.Orders.Update(order);
            foreach (var item in cartItems)
            {
                await _unitOfWork.CartItems.Delete(item.CartItemId);
            }
            await _unitOfWork.SaveChangesAsync();
           
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
                return ApiResponse<bool>.Fail(false,"Order is null", ResponseType.NoContent);
            order.PaymentStatus=updateOrderDto.PaymentStatus;
            order.OrderStatus = updateOrderDto.OrderStatus;
            await genericRepo.Update(order);
            await genericRepo.SaveChangesAsync();
            return ApiResponse<bool>.Success(true, "Order updated successfully", ResponseType.Ok);
        }
    }
}
