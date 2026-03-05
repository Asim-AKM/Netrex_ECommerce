namespace Application_Service.Services.CartAndOrderModuleServices.CartServices.Interface
{
    public interface ICartManager
    {


        Task<ApiResponse<GetCartDto>> CreateAsync(AddCartDto dto);

        Task<ApiResponse<GetCartDto>> GetByIdAsync(Guid cartId);

        Task<ApiResponse<List<GetCartDto>>> GetAllAsync();

        Task<ApiResponse<bool>> UpdateAsync(UpdateCartDto dto);

        Task<ApiResponse<bool>> DeleteAsync(Guid cartId);
    }

}

