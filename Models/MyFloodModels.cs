using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.Models.MyFlood;

public class ResidentialQuoteRequest
{
    [Required]
    public Location Location { get; set; } = new();
    
    [Required]
    public PropertyDetails PropertyDetails { get; set; } = new();
    
    [Required]
    public Coverage Coverage { get; set; } = new();
}

public class Location
{
    [Required]
    [StringLength(200)]
    public string Address { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;
    
    [Required]
    public string State { get; set; } = string.Empty;
    
    [Required]
    [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid ZIP code format")]
    public string ZipCode { get; set; } = string.Empty;
    
    [Required]
    public string FloodZone { get; set; } = string.Empty;
}

public class PropertyDetails
{
    [Required]
    public string PropertyType { get; set; } = string.Empty;
    
    [Required]
    public string ConstructionType { get; set; } = string.Empty;
    
    [Required]
    [Range(1800, 2024, ErrorMessage = "Year built must be between 1800 and 2024")]
    public int YearBuilt { get; set; }
    
    [Required]
    [Range(100, int.MaxValue, ErrorMessage = "Square footage must be at least 100")]
    public int SquareFootage { get; set; }
    
    [Required]
    public int NumberOfFloors { get; set; }
    
    [Required]
    public string Basement { get; set; } = string.Empty;
    
    [Required]
    public string FoundationType { get; set; } = string.Empty;
}

public class Coverage
{
    [Required]
    [Range(0, 1000000, ErrorMessage = "Building coverage must be between $0 and $1,000,000")]
    public int BuildingCoverage { get; set; }
    
    [Required]
    [Range(0, 500000, ErrorMessage = "Contents coverage must be between $0 and $500,000")]
    public int ContentsCoverage { get; set; }
    
    [Required]
    public int Deductible { get; set; }
}

public class QuoteResponse
{
    public string QuoteId { get; set; } = string.Empty;
    public decimal Premium { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public CoverageDetails CoverageDetails { get; set; } = new();
}

public class CoverageDetails
{
    public int BuildingCoverage { get; set; }
    public int ContentsCoverage { get; set; }
    public int Deductible { get; set; }
    public string FloodZone { get; set; } = string.Empty;
}

public class ErrorResponse
{
    public ErrorDetail Error { get; set; } = new();
}

public class ErrorDetail
{
    public string Message { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}

// Enum helper classes for dropdown options
public static class PropertyEnums
{
    public static readonly Dictionary<string, string> States = new()
    {
        { "AL", "Alabama" }, { "AK", "Alaska" }, { "AZ", "Arizona" }, { "AR", "Arkansas" },
        { "CA", "California" }, { "CO", "Colorado" }, { "CT", "Connecticut" }, { "DE", "Delaware" },
        { "FL", "Florida" }, { "GA", "Georgia" }, { "HI", "Hawaii" }, { "ID", "Idaho" },
        { "IL", "Illinois" }, { "IN", "Indiana" }, { "IA", "Iowa" }, { "KS", "Kansas" },
        { "KY", "Kentucky" }, { "LA", "Louisiana" }, { "ME", "Maine" }, { "MD", "Maryland" },
        { "MA", "Massachusetts" }, { "MI", "Michigan" }, { "MN", "Minnesota" }, { "MS", "Mississippi" },
        { "MO", "Missouri" }, { "MT", "Montana" }, { "NE", "Nebraska" }, { "NV", "Nevada" },
        { "NH", "New Hampshire" }, { "NJ", "New Jersey" }, { "NM", "New Mexico" }, { "NY", "New York" },
        { "NC", "North Carolina" }, { "ND", "North Dakota" }, { "OH", "Ohio" }, { "OK", "Oklahoma" },
        { "OR", "Oregon" }, { "PA", "Pennsylvania" }, { "RI", "Rhode Island" }, { "SC", "South Carolina" },
        { "SD", "South Dakota" }, { "TN", "Tennessee" }, { "TX", "Texas" }, { "UT", "Utah" },
        { "VT", "Vermont" }, { "VA", "Virginia" }, { "WA", "Washington" }, { "WV", "West Virginia" },
        { "WI", "Wisconsin" }, { "WY", "Wyoming" }
    };

    public static readonly Dictionary<string, string> FloodZones = new()
    {
        { "A", "Zone A - High Risk" },
        { "AE", "Zone AE - High Risk with Base Flood Elevations" },
        { "AH", "Zone AH - High Risk, Shallow Flooding" },
        { "AO", "Zone AO - High Risk, Sheet Flow" },
        { "AR", "Zone AR - High Risk, Temporarily Protected" },
        { "V", "Zone V - High Risk, Coastal" },
        { "VE", "Zone VE - High Risk, Coastal with Base Flood Elevations" },
        { "X", "Zone X - Moderate to Low Risk" },
        { "B", "Zone B - Moderate Risk" },
        { "C", "Zone C - Minimal Risk" }
    };

    public static readonly Dictionary<string, string> PropertyTypes = new()
    {
        { "SingleFamily", "Single Family Home" },
        { "Townhouse", "Townhouse" },
        { "Condo", "Condominium" },
        { "Manufactured", "Manufactured/Mobile Home" },
        { "Other", "Other" }
    };

    public static readonly Dictionary<string, string> ConstructionTypes = new()
    {
        { "Frame", "Frame/Wood" },
        { "MasonryVeneer", "Masonry Veneer" },
        { "MasonryWall", "Masonry Wall" },
        { "Concrete", "Concrete" },
        { "Steel", "Steel" },
        { "Other", "Other" }
    };

    public static readonly Dictionary<int, string> NumberOfFloors = new()
    {
        { 1, "1 Floor" },
        { 2, "2 Floors" },
        { 3, "3 Floors" },
        { 4, "4 Floors" }
    };

    public static readonly Dictionary<string, string> BasementTypes = new()
    {
        { "None", "No Basement" },
        { "Partial", "Partial Basement" },
        { "Full", "Full Basement" },
        { "Walkout", "Walkout Basement" }
    };

    public static readonly Dictionary<string, string> FoundationTypes = new()
    {
        { "Slab", "Slab on Grade" },
        { "Crawlspace", "Crawlspace" },
        { "Basement", "Basement" },
        { "Pier", "Pier & Beam" },
        { "Post", "Post & Beam" },
        { "Other", "Other" }
    };

    public static readonly Dictionary<int, string> Deductibles = new()
    {
        { 500, "$500" },
        { 1000, "$1,000" },
        { 2000, "$2,000" },
        { 5000, "$5,000" },
        { 10000, "$10,000" }
    };
}