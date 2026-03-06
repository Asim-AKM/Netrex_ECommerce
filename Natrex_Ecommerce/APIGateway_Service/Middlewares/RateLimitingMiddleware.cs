using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace APIGateway_Service.Middlewares
{
    public static class RateLimitingMiddleware
    {
        public static Action<RateLimiterOptions> GetGlobalRateLimiter()
        {
            return options =>
            {
                // Global rate limiter – sab APIs ke liye same policy
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(
                    // Har request ke liye partition key decide karo (yahan fixed key)
                    httpContext => RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: "global_limiter",   // sab ek hi partition mein
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 15,                    // 15 requests per window
                            Window = TimeSpan.FromSeconds(10),   // 10 second ka window
                            QueueLimit = 5,                       // 5 requests queue ho sakti hain
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            AutoReplenishment = true
                        }
                    )
                );

                // Jab limit exceed ho jaye to custom response do
                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    context.HttpContext.Response.ContentType = "application/json";

                    var response = new
                    {
                        error = "Due to your slow internet connection server is unable to respond.",
                        retryAfter = "10 seconds"
                    };

                    await context.HttpContext.Response.WriteAsJsonAsync(response, token);
                };
            };

        }
    }
}
