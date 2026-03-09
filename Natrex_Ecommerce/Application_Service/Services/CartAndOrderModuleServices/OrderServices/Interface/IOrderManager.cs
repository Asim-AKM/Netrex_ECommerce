namespace Application_Service.Services.CartAndOrderModuleServices.OrderServices.Interface
{
        public interface IOrderManager
        {
            Task<ApiResponse<GetOrderDto>> CreateOrderAsync(Guid customerId, PaymentDetailDto paymentDetail);
            Task<ApiResponse<IEnumerable<GetOrderDto>>> GetOrdersByCustomerIdAsync(Guid customerId);
            Task<ApiResponse<GetOrderDto>> GetOrderByIdAsync(Guid orderId);
            Task<ApiResponse<bool>> CancelOrderAsync(Guid orderId);
            Task<ApiResponse<bool>> UpdateOrderStatusAsync(UpdateOrderDto updateOrderDto);
        }
}
