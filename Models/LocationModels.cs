namespace BlazorWebAppMovies.Models;

public class LocationSearchResult
{
    public string? DisplayName { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public decimal Lat { get; set; }
    public decimal Lon { get; set; }
}

public class NominatimResult
{
    public int PlaceId { get; set; }
    public string? DisplayName { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? Lat { get; set; }
    public string? Lon { get; set; }
    public string? Type { get; set; }
}