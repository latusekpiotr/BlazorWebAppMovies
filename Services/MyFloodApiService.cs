using BlazorWebAppMovies.Models.MyFlood;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BlazorWebAppMovies.Services;

public class MyFloodApiService
{
    private readonly HttpClient _httpClient;
    private readonly MyFloodOptions _options;
    private readonly ILogger<MyFloodApiService> _logger;

    public MyFloodApiService(HttpClient httpClient, IOptions<MyFloodOptions> options, ILogger<MyFloodApiService> logger)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _logger = logger;
        _httpClient.BaseAddress = new Uri(_options.ApiUrl);
    }

    public async Task<QuoteResponse?> GetResidentialQuoteAsync(ResidentialQuoteRequest request)
    {
        try
        {
            // For demo purposes, simulate API delay and create a mock response
            await Task.Delay(2000);

            // Simulate an API response based on the request
            var mockResponse = new QuoteResponse
            {
                QuoteId = $"Q{DateTime.Now:yyyyMMddHHmmss}",
                Premium = CalculatePremium(request),
                EffectiveDate = DateTime.Today,
                ExpirationDate = DateTime.Today.AddYears(1),
                CoverageDetails = new CoverageDetails
                {
                    BuildingCoverage = request.Coverage.BuildingCoverage,
                    ContentsCoverage = request.Coverage.ContentsCoverage,
                    Deductible = request.Coverage.Deductible,
                    FloodZone = request.Location.FloodZone
                }
            };

            _logger.LogInformation("Successfully generated mock quote with ID: {QuoteId}", mockResponse.QuoteId);
            return mockResponse;

            /* Real API call would look like this:
            var jsonContent = JsonSerializer.Serialize(request, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            _logger.LogInformation("Requesting residential quote from MyFlood API");

            var response = await _httpClient.PostAsync("/api/v1/quote/residential", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var quoteResponse = JsonSerializer.Deserialize<QuoteResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                _logger.LogInformation("Successfully received quote with ID: {QuoteId}", quoteResponse?.QuoteId);
                return quoteResponse;
            }
            else
            {
                _logger.LogWarning("API request failed with status {StatusCode}: {Content}", response.StatusCode, responseContent);
                
                try
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    
                    throw new MyFloodApiException(errorResponse?.Error?.Message ?? "Unknown API error", response.StatusCode);
                }
                catch (JsonException)
                {
                    throw new MyFloodApiException($"API request failed with status {response.StatusCode}", response.StatusCode);
                }
            }
            */
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Network error when calling MyFlood API");
            throw new MyFloodApiException("Unable to connect to MyFlood API. Please check your internet connection.", null);
        }
        catch (TaskCanceledException ex)
        {
            _logger.LogError(ex, "Request timeout when calling MyFlood API");
            throw new MyFloodApiException("Request timeout. Please try again.", null);
        }
    }

    private decimal CalculatePremium(ResidentialQuoteRequest request)
    {
        // Simple premium calculation logic for demo
        decimal basePremium = 500;
        
        // Risk factor based on flood zone
        decimal zoneFactor = request.Location.FloodZone switch
        {
            "A" or "AE" or "AH" or "AO" or "AR" => 1.5m,
            "V" or "VE" => 2.0m,
            "X" => 0.8m,
            "B" => 0.9m,
            "C" => 0.7m,
            _ => 1.0m
        };

        // Coverage factor
        decimal coverageFactor = (request.Coverage.BuildingCoverage + request.Coverage.ContentsCoverage) / 100000m;

        // Deductible factor
        decimal deductibleFactor = request.Coverage.Deductible switch
        {
            500 => 1.2m,
            1000 => 1.0m,
            2000 => 0.9m,
            5000 => 0.8m,
            10000 => 0.7m,
            _ => 1.0m
        };

        // Age factor
        int age = DateTime.Now.Year - request.PropertyDetails.YearBuilt;
        decimal ageFactor = age > 50 ? 1.3m : age > 20 ? 1.1m : 1.0m;

        return Math.Round(basePremium * zoneFactor * coverageFactor * deductibleFactor * ageFactor, 2);
    }
}

public class MyFloodOptions
{
    public string ApiUrl { get; set; } = string.Empty;
}

public class MyFloodApiException : Exception
{
    public System.Net.HttpStatusCode? StatusCode { get; }

    public MyFloodApiException(string message, System.Net.HttpStatusCode? statusCode = null) : base(message)
    {
        StatusCode = statusCode;
    }

    public MyFloodApiException(string message, Exception innerException, System.Net.HttpStatusCode? statusCode = null) : base(message, innerException)
    {
        StatusCode = statusCode;
    }
}