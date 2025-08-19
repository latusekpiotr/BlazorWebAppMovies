namespace BlazorWebAppMovies.Models;

public class WeatherData
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string? Timezone { get; set; }
    public Current? Current { get; set; }
    public Daily? Daily { get; set; }
}

public class Current
{
    public string? Time { get; set; }
    public decimal Temperature2m { get; set; }
    public int WeatherCode { get; set; }
}

public class Daily
{
    public string[]? Time { get; set; }
    public decimal[]? Temperature2mMax { get; set; }
    public decimal[]? Temperature2mMin { get; set; }
    public int[]? WeatherCode { get; set; }
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public decimal TemperatureC { get; set; }
    public decimal TemperatureMinC { get; set; }
    public string? Summary { get; set; }
    public decimal TemperatureF => 32 + (TemperatureC * 9 / 5);
    public decimal TemperatureMinF => 32 + (TemperatureMinC * 9 / 5);
}