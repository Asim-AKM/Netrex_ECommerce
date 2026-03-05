namespace Application_Service.Services.CartAndOrderModuleServices.OrderServices.Interface
{
    public interface IOrderItemManager
    { 
        Task<ApiResponse<IEnumerable<GetOrderItemDto>>>GetOrderItemsByOrderId(Guid orderId);
    }
}
