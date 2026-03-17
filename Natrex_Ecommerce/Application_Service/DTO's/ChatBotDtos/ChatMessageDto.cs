namespace Application_Service.DTO_s.ChatBotDtos
{
    public class ChatMessageDto
    {
        public string? Role { get; set; }
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
