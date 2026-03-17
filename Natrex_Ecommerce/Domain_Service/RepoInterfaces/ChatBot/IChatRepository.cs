using Domain_Service.Entities.ChatBotModule;

namespace Domain_Service.RepoInterfaces.ChatBot
{
    public interface IChatRepository
    {
        Task<ChatSession> CreateSessionAsync(Guid userId);
        Task<ChatSession> GetSessionAsync(Guid sessionId);
        Task<IEnumerable<ChatMessage>> GetSessionMessagesAsync(Guid sessionId, int limit = 50);
        Task AddMessageAsync(ChatMessage message);
        Task<IEnumerable<ChatSession>> GetUserSessionsAsync(Guid userId);
        Task SaveChangesAsync();
    }
}
