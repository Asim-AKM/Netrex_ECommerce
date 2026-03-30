namespace Application_Service.DTO_s.ChatBotDtos
{
    public class ChatResponseDto
    {
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid SessionId { get; set; }
    }
}
