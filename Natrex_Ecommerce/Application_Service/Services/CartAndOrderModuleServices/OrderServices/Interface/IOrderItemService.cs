using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.CartAndOrderDtos.OrderItemDtos;

namespace Application_Service.Services.CartAndOrderModuleServices.OrderServices.Interface
{
    public interface IOrderItemService
    { 
        Task<ApiResponse<IEnumerable<GetOrderItemDto>>>GetOrderItemsByOrderId(Guid orderId);
    }
}
