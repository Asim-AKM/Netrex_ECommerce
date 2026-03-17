using Application_Service.DTO_s.ChatBotDtos;
using Application_Service.Services.ChatBotService.Interfaces;
using Domain_Service.Entities.ChatBotModule;
using Domain_Service.RepoInterfaces.ChatBot;

namespace Application_Service.Services.ChatBotService.Implementations
{
    public class ChatManager : IChatManager
    {
        private readonly IChatRepository _chatRepository;
        private readonly IAIService _aiService;
        private readonly ILogger<ChatManager> _logger;

        public ChatManager(
            IChatRepository chatRepository,
            IAIService aiService,
            ILogger<ChatManager> logger)
        {
            _chatRepository = chatRepository;
            _aiService = aiService;
            _logger = logger;
        }

        public async Task<ApiResponse<ChatResponseDto>> ProcessMessageAsync(Guid userId, string message)
        {
            var requestId = GenerateRequestId();

            try
            {
                LogStart(requestId, userId);

                var validationError = ValidateMessage(message, requestId, userId);
                if (validationError != null)
                    return validationError;

                var session = await GetOrCreateSession(userId, requestId);
                if (session == null)
                    return Fail("Unable to access chat session.");

                var history = await GetChatHistory(session.Id, requestId);

                var aiResponse = await GetAIResponse(message, history, requestId);
                if (aiResponse.IsError)
                    return aiResponse.ErrorResponse;

                await SaveMessages(userId, session.Id, message, aiResponse.Data, requestId);

                var response = BuildResponse(session.Id, aiResponse.Data);

                LogSuccess(requestId, userId);

                return ApiResponse<ChatResponseDto>.Success(response, "Message processed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{RequestId}] Unexpected error for user: {UserId}", requestId, userId);
                return Fail("An unexpected system error occurred.");
            }
        }

        //Helpers

        private string GenerateRequestId() => Guid.NewGuid().ToString()[..8];

        private void LogStart(string requestId, Guid userId)
        {
            _logger.LogInformation("[{RequestId}] Processing chat for user: {UserId}", requestId, userId);
        }

        private void LogSuccess(string requestId, Guid userId)
        {
            _logger.LogInformation("[{RequestId}] Completed successfully for user: {UserId}", requestId, userId);
        }

        private ApiResponse<ChatResponseDto>? ValidateMessage(string message, string requestId, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                _logger.LogWarning("[{RequestId}] Empty message from user: {UserId}", requestId, userId);
                return Fail("Message cannot be empty", ResponseType.BadRequest);
            }
            return null;
        }

        private async Task<ChatSession?> GetOrCreateSession(Guid userId, string requestId)
        {
            try
            {
                var sessions = await _chatRepository.GetUserSessionsAsync(userId);
                var activeSession = sessions?.FirstOrDefault(s => s.EndedAt == null);

                if (activeSession != null)
                {
                    _logger.LogInformation("[{RequestId}] Using session: {SessionId}", requestId, activeSession.Id);
                    return activeSession;
                }

                _logger.LogInformation("[{RequestId}] Creating new session", requestId);
                return await _chatRepository.CreateSessionAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{RequestId}] Session error", requestId);
                return null;
            }
        }

        private async Task<List<ChatMessageDto>> GetChatHistory(Guid sessionId, string requestId)
        {
            try
            {
                var messages = await _chatRepository.GetSessionMessagesAsync(sessionId, 20);

                var history = messages.Select(m => new ChatMessageDto
                {
                    Role = m.Role,
                    Content = m.Content,
                    Timestamp = m.Timestamp
                }).ToList();

                _logger.LogInformation("[{RequestId}] Loaded {Count} messages", requestId, history.Count);

                return history;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{RequestId}] Error loading history", requestId);
                return new List<ChatMessageDto>();
            }
        }

        private async Task<(bool IsError, string Data, ApiResponse<ChatResponseDto>? ErrorResponse)>
            GetAIResponse(string message, List<ChatMessageDto> history, string requestId)
        {
            try
            {
                var response = await _aiService.AskQuestionAsync(message, history);

                if (string.IsNullOrWhiteSpace(response))
                    response = "I couldn't generate a response. Please try again.";

                return (false, response, null);
            }
            catch (HttpRequestException)
            {
                return (true, "", Fail("Network error. Please try again."));
            }
            catch (TimeoutException)
            {
                return (true, "", Fail("AI service timeout. Try again."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{RequestId}] AI error", requestId);
                return (true, "", Fail("AI service unavailable."));
            }
        }

        private async Task SaveMessages(Guid userId, Guid sessionId, string userMessage, string aiResponse, string requestId)
        {
            try
            {
                var messages = new List<ChatMessage>
                {
                    CreateMessage(userId, sessionId, "user", userMessage),
                    CreateMessage(userId, sessionId, "assistant", aiResponse)
                };

                foreach (var msg in messages)
                    await _chatRepository.AddMessageAsync(msg);

                await _chatRepository.SaveChangesAsync();

                _logger.LogInformation("[{RequestId}] Messages saved", requestId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{RequestId}] Error saving messages", requestId);
            }
        }

        private ChatMessage CreateMessage(Guid userId, Guid sessionId, string role, string content)
        {
            return new ChatMessage
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                SessionId = sessionId,
                Role = role,
                Content = content,
                Timestamp = DateTime.UtcNow
            };
        }

        private ChatResponseDto BuildResponse(Guid sessionId, string message)
        {
            return new ChatResponseDto
            {
                Message = message,
                Timestamp = DateTime.UtcNow,
                SessionId = sessionId
            };
        }

        private ApiResponse<ChatResponseDto> Fail(string msg, ResponseType type = ResponseType.InternalServerError)
        {
            return ApiResponse<ChatResponseDto>.Fail(msg, type);
        }
    }
}