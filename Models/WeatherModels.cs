using System.Text.Json.Serialization;

namespace BlazorWebAppMovies.Models;

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public decimal TemperatureC { get; set; }
    public string? Summary { get; set; }
    public decimal TemperatureF => Math.Round(32 + (TemperatureC * 9 / 5), 1);
}

public class OpenMeteoResponse
{
    [JsonPropertyName("latitude")]
    public decimal Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public decimal Longitude { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; } = string.Empty;

    [JsonPropertyName("daily")]
    public DailyWeather Daily { get; set; } = new();

    [JsonPropertyName("current_weather")]
    public CurrentWeather CurrentWeather { get; set; } = new();
}

public class DailyWeather
{
    [JsonPropertyName("time")]
    public string[] Time { get; set; } = Array.Empty<string>();

    [JsonPropertyName("temperature_2m_max")]
    public decimal[] TemperatureMax { get; set; } = Array.Empty<decimal>();

    [JsonPropertyName("temperature_2m_min")]
    public decimal[] TemperatureMin { get; set; } = Array.Empty<decimal>();

    [JsonPropertyName("weathercode")]
    public int[] WeatherCode { get; set; } = Array.Empty<int>();
}

public class CurrentWeather
{
    [JsonPropertyName("temperature")]
    public decimal Temperature { get; set; }

    [JsonPropertyName("weathercode")]
    public int WeatherCode { get; set; }
}

public static class WeatherCodeHelper
{
    private static readonly Dictionary<int, string> WeatherCodes = new()
    {
        { 0, "Clear sky" },
        { 1, "Mainly clear" },
        { 2, "Partly cloudy" },
        { 3, "Overcast" },
        { 45, "Fog" },
        { 48, "Depositing rime fog" },
        { 51, "Light drizzle" },
        { 53, "Moderate drizzle" },
        { 55, "Dense drizzle" },
        { 56, "Light freezing drizzle" },
        { 57, "Dense freezing drizzle" },
        { 61, "Slight rain" },
        { 63, "Moderate rain" },
        { 65, "Heavy rain" },
        { 66, "Light freezing rain" },
        { 67, "Heavy freezing rain" },
        { 71, "Slight snow fall" },
        { 73, "Moderate snow fall" },
        { 75, "Heavy snow fall" },
        { 77, "Snow grains" },
        { 80, "Slight rain showers" },
        { 81, "Moderate rain showers" },
        { 82, "Violent rain showers" },
        { 85, "Slight snow showers" },
        { 86, "Heavy snow showers" },
        { 95, "Thunderstorm" },
        { 96, "Thunderstorm with slight hail" },
        { 99, "Thunderstorm with heavy hail" }
    };

    public static string GetDescription(int weatherCode)
    {
        return WeatherCodes.TryGetValue(weatherCode, out var description) 
            ? description 
            : "Unknown";
    }
}