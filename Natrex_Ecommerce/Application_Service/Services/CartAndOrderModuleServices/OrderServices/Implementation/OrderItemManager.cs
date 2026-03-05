namespace Application_Service.Services.CartAndOrderModuleServices.OrderServices.Implementation
{
    public class OrderItemManager(IOrderItemRepo repo) : IOrderItemManager
    {
        public async Task<ApiResponse<IEnumerable<GetOrderItemDto>>> GetOrderItemsByOrderId(Guid orderId)
        {
            var data = await repo.GetOrderItemsByOrderIdAsync(orderId);
            if (data == null || !data.Any())
            {
                return ApiResponse<IEnumerable<GetOrderItemDto>>
                    .Fail("No order items found for the given order ID", ResponseType.NotFound);
            }
            return ApiResponse<IEnumerable<GetOrderItemDto>>
                .Success(data.MapList(), "Order items retrieved successfully", ResponseType.Ok);
        }
 
    }
}
