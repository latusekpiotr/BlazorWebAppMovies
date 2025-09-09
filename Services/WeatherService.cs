using System.Text.Json;
using BlazorWebAppMovies.Models;

namespace BlazorWebAppMovies.Services;

public interface IWeatherService
{
    Task<WeatherForecast[]> GetWeatherForecastAsync();
}

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<WeatherService> _logger;

    // London, UK coordinates
    private const decimal LondonLatitude = 51.5074m;
    private const decimal LondonLongitude = -0.1278m;

    public WeatherService(HttpClient httpClient, ILogger<WeatherService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<WeatherForecast[]> GetWeatherForecastAsync()
    {
        try
        {
            var url = BuildApiUrl();
            _logger.LogInformation("Fetching weather data from Open-Meteo API for London, UK");

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var weatherData = JsonSerializer.Deserialize<OpenMeteoResponse>(jsonContent, options);

            if (weatherData?.Daily == null)
            {
                _logger.LogWarning("No daily weather data received from API");
                return Array.Empty<WeatherForecast>();
            }

            return ConvertToWeatherForecast(weatherData);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching weather data from Open-Meteo API");
            // Return fallback data if API fails
            return GetFallbackWeatherData();
        }
    }

    private static string BuildApiUrl()
    {
        return $"https://api.open-meteo.com/v1/forecast" +
               $"?latitude={LondonLatitude}" +
               $"&longitude={LondonLongitude}" +
               $"&daily=temperature_2m_max,temperature_2m_min,weathercode" +
               $"&current_weather=true" +
               $"&timezone=Europe/London" +
               $"&forecast_days=5";
    }

    private static WeatherForecast[] ConvertToWeatherForecast(OpenMeteoResponse weatherData)
    {
        var forecasts = new List<WeatherForecast>();

        for (int i = 0; i < Math.Min(weatherData.Daily.Time.Length, 5); i++)
        {
            if (DateTime.TryParse(weatherData.Daily.Time[i], out var date))
            {
                var maxTemp = weatherData.Daily.TemperatureMax.Length > i ? weatherData.Daily.TemperatureMax[i] : 0;
                var minTemp = weatherData.Daily.TemperatureMin.Length > i ? weatherData.Daily.TemperatureMin[i] : 0;
                var avgTemp = (maxTemp + minTemp) / 2;
                var weatherCode = weatherData.Daily.WeatherCode.Length > i ? weatherData.Daily.WeatherCode[i] : 0;

                forecasts.Add(new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(date),
                    TemperatureC = Math.Round(avgTemp, 1),
                    Summary = WeatherCodeHelper.GetDescription(weatherCode)
                });
            }
        }

        return forecasts.ToArray();
    }

    private static WeatherForecast[] GetFallbackWeatherData()
    {
        // Fallback data if API is unavailable
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Partly cloudy", "Light rain", "Overcast", "Clear sky", "Moderate rain" };
        
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = 15 + (index % 10) - 5, // Generate reasonable London temperatures
            Summary = summaries[(index - 1) % summaries.Length]
        }).ToArray();
    }
}