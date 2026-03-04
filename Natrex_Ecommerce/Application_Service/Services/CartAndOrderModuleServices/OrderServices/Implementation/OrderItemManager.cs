using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.CartAndOrderModuleMappers.OrderItemMappers;
using Application_Service.DTO_s.CartAndOrderDtos.OrderItemDtos;
using Application_Service.Services.CartAndOrderModuleServices.OrderServices.Interface;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.CartAndOrderRepo.OrderRepos;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.CartAndOrderModuleServices.OrderServices.Implementation
{
    public class OrderItemManager(IUnitOfWork unitOfWork) : IOrderItemManager
    {
        public async Task<ApiResponse<IEnumerable<GetOrderItemDto>>> GetOrderItemsByOrderId(Guid orderId)
        {
            var data = await unitOfWork.OrderItemRepo.GetOrderItemsByOrderIdAsync(orderId);
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
