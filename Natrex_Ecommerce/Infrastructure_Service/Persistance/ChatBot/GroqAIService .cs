using Application_Service.DTO_s.ChatBotDtos;
using Application_Service.Services.ChatBotService.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace ECommerce.Infrastructure.Services
{
    public class GroqAIService : IAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly ILogger<GroqAIService> _logger;
        private const string GROQ_API_URL = "https://api.groq.com/openai/v1/chat/completions";

        public GroqAIService(IConfiguration configuration, ILogger<GroqAIService> logger)
        {
            _logger = logger;
            _apiKey = configuration["Groq:ApiKey"]
                ?? throw new InvalidOperationException("Groq API key is missing.");

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            _logger.LogInformation("GroqAIService initialized with direct HTTP client");
        }

        public async Task<string> AskQuestionAsync(string userMessage, List<ChatMessageDto> chatHistory)
        {
            try
            {
                _logger.LogInformation("AskQuestionAsync called with message: {Message}", userMessage);

                // Prepare messages list
                var messages = new List<object>();

                // System prompt
                messages.Add(new { role = "system", content = "You are an e-commerce website assistant. Your job is to answer questions about products, orders, and the website. If you don't know something, politely say that you don't have that information." });

                // Add chat history
                if (chatHistory != null)
                {
                    foreach (var msg in chatHistory.Where(m => m != null))
                    {
                        messages.Add(new { role = msg.Role, content = msg.Content });
                    }
                }

               
                messages.Add(new { role = "user", content = userMessage });

               
                var requestBody = new
                {
                    model = "llama-3.3-70b-versatile", 
                   
                    messages = messages,
                    temperature = 0.7,
                    max_tokens = 1024
                };

                var content = new StringContent(
                    JsonSerializer.Serialize(requestBody),
                    Encoding.UTF8,
                    "application/json");

                _logger.LogInformation("Sending request to Groq API with model: {Model}", requestBody.model);

                var response = await _httpClient.PostAsync(GROQ_API_URL, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Groq API error: {StatusCode} - {Error}",
                        response.StatusCode, errorContent);
                    throw new Exception($"Groq API returned {response.StatusCode}: {errorContent}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GroqResponse>(responseContent);

                var aiResponse = result?.choices?.FirstOrDefault()?.message?.content
                    ?? throw new Exception("Empty response from AI service");

                _logger.LogInformation("Groq API response received successfully");

                return aiResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Groq API call failed");
                throw new Exception($"Groq AI service error: {ex.Message}", ex);
            }
        }

        // Response DTOs
        private class GroqResponse
        {
            public GroqChoice[] choices { get; set; }
        }

        private class GroqChoice
        {
            public GroqMessageResponse message { get; set; }
        }

        private class GroqMessageResponse
        {
            public string content { get; set; }
        }
    }
}