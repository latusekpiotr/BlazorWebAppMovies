using BlazorWebAppMovies.Models;
using System.Text.Json;
using System.Globalization;

namespace BlazorWebAppMovies.Services;

public class NominatimService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public NominatimService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "BlazorWeatherApp/1.0");
        
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
    }

    public async Task<LocationSearchResult[]> SearchLocationsAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query) || query.Length < 2)
            return Array.Empty<LocationSearchResult>();

        try
        {
            var encodedQuery = Uri.EscapeDataString(query);
            var url = $"https://nominatim.openstreetmap.org/search?q={encodedQuery}&format=json&limit=5&addressdetails=1";
            
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            var nominatimResults = JsonSerializer.Deserialize<NominatimResult[]>(json, _jsonOptions);
            
            if (nominatimResults == null)
                return Array.Empty<LocationSearchResult>();

            var results = new List<LocationSearchResult>();
            
            foreach (var result in nominatimResults.Take(5))
            {
                if (decimal.TryParse(result.Lat, NumberStyles.Float, CultureInfo.InvariantCulture, out var lat) &&
                    decimal.TryParse(result.Lon, NumberStyles.Float, CultureInfo.InvariantCulture, out var lon))
                {
                    var location = new LocationSearchResult
                    {
                        DisplayName = result.DisplayName ?? result.Name ?? "Unknown Location",
                        Name = result.Name ?? "Unknown",
                        Country = result.Country,
                        State = result.State,
                        Lat = lat,
                        Lon = lon
                    };
                    results.Add(location);
                }
            }
            
            return results.ToArray();
        }
        catch (Exception ex)
        {
            // Log error in production app
            Console.WriteLine($"Error searching locations: {ex.Message}");
            return Array.Empty<LocationSearchResult>();
        }
    }
}