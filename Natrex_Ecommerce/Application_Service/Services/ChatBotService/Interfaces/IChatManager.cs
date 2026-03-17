using Application_Service.DTO_s.ChatBotDtos;

namespace Application_Service.Services.ChatBotService.Interfaces
{
    public interface IChatManager
    {
        Task<ApiResponse<ChatResponseDto>> ProcessMessageAsync(Guid userId, string message);
    }
}
