using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.CartAndOrderDtos.OrderDtos;

namespace Application_Service.Services.CartAndOrderServices.OrderServices.Interface
{
        public interface IOrderService
        {
            Task<ApiResponse<GetOrderDto>> CreateOrderAsync(AddOrderDto orderDto);
            Task<ApiResponse<IEnumerable<GetOrderDto>>> GetOrdersByCustomerIdAsync(Guid customerId);
            Task<ApiResponse<GetOrderDto>> GetOrderByIdAsync(Guid orderId);
            Task<ApiResponse<bool>> CancelOrderAsync(Guid orderId);
            Task<ApiResponse<bool>> UpdateOrderStatusAsync(UpdateOrderDto updateOrderDto);
        }
}
