using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.Models.MyFlood;

public class NewQuoteRequest
{
    public Residential? Residential { get; set; }

    [Display(Name = "Contents Cost Value Type")]
    [Required]
    public ContentsCostValueType ContentsCostValueType { get; set; }

    public Foundation? Foundation { get; set; }

    [Display(Name = "Basement Type")]
    [Required]
    public BasementType BasementType { get; set; }

    [Display(Name = "Year Built")]
    [Required]
    [Range(1600, 2025, ErrorMessage = "Year built must be between 1600 and 2025")]
    public int YearBuilt { get; set; }

    [Display(Name = "Square Footage")]
    [Required]
    [Range(1, 50000, ErrorMessage = "Square footage must be between 1 and 50,000")]
    public int SquareFootage { get; set; }

    [Display(Name = "Number of Stories")]
    [Required]
    [Range(1, 10, ErrorMessage = "Number of stories must be between 1 and 10")]
    public int NumberOfStories { get; set; }

    [Display(Name = "Elevation Height")]
    [Range(0, 500, ErrorMessage = "Elevation height must be between 0 and 500 feet")]
    public double? ElevationHeight { get; set; }

    [Display(Name = "Building Over Water")]
    [Required]
    public BuildingOverWaterType BuildingOverWaterType { get; set; }

    public LocationDetail? Location { get; set; }

    public NewQuoteRequest()
    {
        Residential = new Residential();
        Foundation = new Foundation();
        Location = new LocationDetail();
    }
}