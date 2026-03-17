using Application_Service.DTO_s.ChatBotDtos;

namespace Application_Service.Services.ChatBotService.Interfaces
{
    public interface IAIService
    {
        Task<string> AskQuestionAsync(string userMessage, List<ChatMessageDto> chatHistory);
    }
}
