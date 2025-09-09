using BlazorWebAppMovies.Models.MyFlood;
using System.Text.Json;
using System.Text;

namespace BlazorWebAppMovies.Services;

public interface IMyFloodService
{
    Task<QuoteResponseMessage> GetQuoteAsync(NewQuoteRequest request);
}

public class MyFloodService : IMyFloodService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<MyFloodService> _logger;

    public MyFloodService(HttpClient httpClient, IConfiguration configuration, ILogger<MyFloodService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<QuoteResponseMessage> GetQuoteAsync(NewQuoteRequest request)
    {
        try
        {
            var baseUrl = _configuration["MyFlood:ApiBaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new InvalidOperationException("MyFlood API base URL not configured");
            }

            var requestUri = $"{baseUrl.TrimEnd('/')}/quote";
            
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var jsonContent = JsonSerializer.Serialize(request, jsonOptions);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            _logger.LogInformation("Sending quote request to MyFlood API: {RequestUri}", requestUri);

            var response = await _httpClient.PostAsync(requestUri, httpContent);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var quoteResponse = JsonSerializer.Deserialize<QuoteResponseMessage>(responseContent, jsonOptions);
                return quoteResponse ?? new QuoteResponseMessage
                {
                    Messages = new Messages
                    {
                        Validation = new List<string> { "Received empty response from API" }
                    }
                };
            }
            else
            {
                // Handle error responses
                _logger.LogWarning("MyFlood API returned error: {StatusCode} - {Content}", response.StatusCode, responseContent);

                // Try to parse as ProblemDetails
                try
                {
                    var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(responseContent, jsonOptions);
                    return new QuoteResponseMessage
                    {
                        Messages = new Messages
                        {
                            Validation = new List<string> 
                            { 
                                problemDetails?.Detail ?? problemDetails?.Title ?? $"API error: {response.StatusCode}" 
                            }
                        }
                    };
                }
                catch
                {
                    return new QuoteResponseMessage
                    {
                        Messages = new Messages
                        {
                            Validation = new List<string> { $"API error {response.StatusCode}: {responseContent}" }
                        }
                    };
                }
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "HTTP error calling MyFlood API");
            return new QuoteResponseMessage
            {
                Messages = new Messages
                {
                    Validation = new List<string> { $"Connection error: {ex.Message}" }
                }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error calling MyFlood API");
            return new QuoteResponseMessage
            {
                Messages = new Messages
                {
                    Validation = new List<string> { $"Unexpected error: {ex.Message}" }
                }
            };
        }
    }
}