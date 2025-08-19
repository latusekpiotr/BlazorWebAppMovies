using BlazorWebAppMovies.Models;
using System.Text.Json;

namespace BlazorWebAppMovies.Services;

public class OpenMeteoService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public OpenMeteoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
    }

    public async Task<WeatherForecast[]> GetWeatherForecastAsync(decimal latitude, decimal longitude)
    {
        try
        {
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude:F4}&longitude={longitude:F4}&current=temperature_2m,weather_code&daily=temperature_2m_max,temperature_2m_min,weather_code&timezone=auto&forecast_days=5";
            
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherData>(json, _jsonOptions);
            
            if (weatherData?.Daily == null)
                return Array.Empty<WeatherForecast>();

            var forecasts = new List<WeatherForecast>();
            
            for (int i = 0; i < Math.Min(5, weatherData.Daily.Time?.Length ?? 0); i++)
            {
                if (weatherData.Daily.Time != null && 
                    weatherData.Daily.Temperature2mMax != null && 
                    weatherData.Daily.Temperature2mMin != null &&
                    weatherData.Daily.WeatherCode != null)
                {
                    var forecast = new WeatherForecast
                    {
                        Date = DateOnly.Parse(weatherData.Daily.Time[i]),
                        TemperatureC = weatherData.Daily.Temperature2mMax[i],
                        TemperatureMinC = weatherData.Daily.Temperature2mMin[i],
                        Summary = GetWeatherDescription(weatherData.Daily.WeatherCode[i])
                    };
                    forecasts.Add(forecast);
                }
            }
            
            return forecasts.ToArray();
        }
        catch (Exception ex)
        {
            // Log error in production app
            Console.WriteLine($"Error fetching weather data: {ex.Message}");
            return Array.Empty<WeatherForecast>();
        }
    }

    private static string GetWeatherDescription(int weatherCode)
    {
        return weatherCode switch
        {
            0 => "Clear sky",
            1 => "Mainly clear",
            2 => "Partly cloudy",
            3 => "Overcast",
            45 or 48 => "Foggy",
            51 or 53 or 55 => "Drizzle",
            56 or 57 => "Freezing drizzle",
            61 or 63 or 65 => "Rain",
            66 or 67 => "Freezing rain",
            71 or 73 or 75 => "Snow",
            77 => "Snow grains",
            80 or 81 or 82 => "Rain showers",
            85 or 86 => "Snow showers",
            95 => "Thunderstorm",
            96 or 99 => "Thunderstorm with hail",
            _ => "Unknown"
        };
    }
}